#OpenCV для обнаружения объектов
import cv2
img = cv2.imread('D:/GeekBrains/04_Bootcamp/Lesson16/test.jpg') # Записываем картинку в переменную

#img = cv2.resize(img, (500, 500))

cv2.imshow('Result', img)

cv2.waitKey(0)