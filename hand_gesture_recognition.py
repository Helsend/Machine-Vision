import math
import numpy as np
import cv2

def bodyskin_detect(frame):
    '''
    通过肤色检测初步划分出感兴趣的区域
    '''
    #通过Cr通道+OTSU检测肤色并进行二值化
    ycrcb=cv2.cvtColor(frame,cv2.COLOR_BGR2YCrCb) #BGR格式转YCrCb格式
    cr=cv2.split(ycrcb)[1] #单独提取Cr通道
    cr1=cv2.GaussianBlur(cr,(7,7),0) #高斯平滑
    skin=cv2.threshold(cr1,0,255,cv2.THRESH_BINARY+cv2.THRESH_OTSU)[1] #二值化

    #膨胀侵蚀去噪
    kernel=np.ones((3,3),np.uint8)
    skin=cv2.dilate(skin,kernel,iterations=5)
    skin=cv2.erode(skin,kernel,iterations=5)
    return skin

def hand_isolate(skin):
    '''
    将手部分分割出来，即找到最大的轮廓
    '''
    contours=cv2.findContours(skin,cv2.RETR_TREE,cv2.CHAIN_APPROX_NONE)[-2] #提取轮廓
    hand_contour=sorted(contours,key=cv2.contourArea)[-1] #按轮廓围出的面积排序并取最大的
    return hand_contour

def get_defects_count(array,contour,defects,verbose=False):
    '''
    根据已知的廓线、凹凸点计算角度，返回角点数
    '''
    ndefects=0
    #对每一个角点进行角度检测
    for i in range(defects.shape[0]):
        #凹点四个存储值含义：起点、终点、轮廓上的距离凸包最远点、最远点到凸包的近似距离，四个点的索引值
        s,e,f,_=defects[i,0]
        #根据索引值找到对应的点
        start=tuple(contour[s][0])
        end=tuple(contour[e][0])
        far=tuple(contour[f][0])
        #始点、终点、角点围出三角形，已知三边求夹角，即余弦公式
        a=((start[0]-end[0])**2+(start[1]-end[1])**2)**(0.5)
        b=((start[0]-far[0])**2+(start[1]-far[1])**2)**(0.5)
        c=((end[0]-far[0])**2+(end[1]-far[1])**2)**(0.5)
        angle=math.acos((b**2+c**2-a**2)/(2*b*c))
        #夹角<=90°则认为是手指间的夹角
        if angle<=math.pi/2:
            ndefects+=1
            #绘制角点
            if verbose:
                cv2.circle(array,far,5,[255,0,0],-1)
        #绘制凸多边形的边
        if verbose:
            cv2.line(array,start,end,[0,0,255],1)
    return ndefects

if __name__=='__main__':
    webcam=cv2.VideoCapture(0)
    while True:
        frame=webcam.read()[1]
        frame=cv2.flip(frame,1)

        #肤色检测
        skin=bodyskin_detect(frame)
        #提取手的边界
        hand_contour=hand_isolate(skin)
        #计算矩形边界框并记录长宽比
        x,y,w,h=cv2.boundingRect(hand_contour)
        aspect_ratio=float(w)/h
        #凹凸点检测，注意convexHull中returnPoints须为false，否则convexityDefects传参格式不对
        hull=cv2.convexHull(hand_contour,returnPoints=False)
        defects=cv2.convexityDefects(hand_contour,hull)
        n=get_defects_count(frame,hand_contour,defects,verbose=True)

        #判断手势0-5
        #0和1角点数量都为0，需要矩形边框长宽比辅助区分
        if n==0 and aspect_ratio>=0.75:
            hand_gesture=str(0)
        elif n==0 and aspect_ratio<0.75:
            hand_gesture=str(1)
        elif n!=0:
            hand_gesture=str(n+1)
        else:
            hand_gesture="null"
        
        #绘制凸多边形边界框、矩形边界框、手势判断结果
        cv2.drawContours(frame,hand_contour,-1,(0,255,0),2)
        cv2.rectangle(frame,(x,y),(x+w,y+h),(0,0,0),2)
        #cv2.putText(frame,"result:"+hand_gesture,(x,y-10),cv2.FONT_HERSHEY_DUPLEX,1,(147,58,31),2)

        #显示处理后的窗口
        cv2.imshow("demo",frame)
        #按esc退出
        if cv2.waitKey(1)==27:
            break
    #释放
    webcam.release()
    cv2.destroyAllWindows()
