from random import randint

x=randint(0,100)

count_perebor=0
#метод последовательного перебора
for i in range(0,101):
    count_perebor+=1
    if i==x:
        print("Число найдено!")
        break

#print("Загаданное число было ",x, " и для его поиска перебором потребовалось ", count_perebor, " итераций ")


count_random=1
#метод случайного отгадывания
y=randint(0,100)
while x!=y:
    y=randint(0,100)
    count_random+=1

#print("Загаданное число было ",x, " и для его поиска угадыванием потребовалось ", count_random, " итераций ")
from random import randint
right=10000000
left=0

array=[1,3,5,8,11,55,66,100]

array2=[555,22,3,1,44,2,33,6,55,100]

x=randint(left,right)


count_bin=1
print('Давай начнем игру - угадай число от 0 до 100')

mid=(right + left) // 2


while x!=mid:
    print(mid)
    if x<mid: 
        print("меньше")
        right=mid-1
    else: 
        print("больше")
        left=mid+1
    mid=(right + left) // 2
   # y=int(input('Введи число'))
    count_bin+=1
print("Загаданное число было ",x, " и для его поиска бинарным алгоритмом потребовалось ", count_bin, " итераций ")