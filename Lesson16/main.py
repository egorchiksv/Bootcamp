#OpenCV для обнаружения объектов
import cv2
img = cv2.imread('test.jpg') # Записываем картинку в переменную
print(img.shape)
img = cv2.resize(img, (500, 500))
print(img.shape)
