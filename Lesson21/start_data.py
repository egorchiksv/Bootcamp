# Написать генетический алгоритм для распределения инвестиций между ЦФО. Т.е., есть регионы, в регионах есть ЦФО, в ЦФО есть проекты.
# Обязательным условием является дейсвующего проекта в каждом регионе (хотя бы один прект должен иметь финансирование), т.к. это гос. структура.abs

# Интерфейс приложения, нужен вывод таблиц с чекбоксом, где на против каждого проекта будет отметка, включать этот проект в финансирование или нет.

# Необходимо найти оптимальное решение распределения инвестиций, учитывая все факторы, не выйти за пределы допустимого финансирования.

# Риск не учитываем в решении.

# В ИТОГЕ:
# 1. Найти оптимальное распределение финансов для максимизации прибыли.
# 2. В каждом регионе должен быть один проект как минимум.
# 3. В случае нехватки финансов центр может проспонсировать часть из своего запаса денег = М.

import random
from tkinter import *


C=[9.95, 3.66, 57.05, 10.485, 11.97, 18.17, 13.425, 3.28, 18.16] #средства, выделяемых конкретным ЦФО на реализацию собственных инвестиционных программ, всего 9 ЦФО значит 9 значений 
M=55.83 #плановый годовой объем финансовых стердств, выделяемым центральной компанией на реализацию нововведений ЦФО
r=11 #допустимая средняя прибыль на 1 руб. затрат (норма прибыли на капитал)
p=1 #ограницения на суммарную рискованность инвестиционного портфеля;
risk=[] #риск по проектам
marja=[] #прибыль от проектов
costs=[] #стоимость проектов
names=[] #имена пректов
#0 регион
risk.append([2.73, 1.63])
marja.append([15.31, 14.68])
costs.append([10.42, 9.48])
names.append(["реконструкция офисных зданий и сооружений", "выделение группы технологического аудита в обособленную структуру"])
#1 регион

risk.append([1.7])
marja.append([14.77])
costs.append([7.32])
names.append(["разработка и внедрение специальных средств упаковки ценных грузов"])
#2 регион

risk.append([1.52, 1.64, 2.32, 1.12])
marja.append([14.03, 15.76, 15.7, 13.08])
costs.append([11.31, 10.85, 13.51, 10.87])
names.append(["приобретение и оборудование бронеавтомобилей", "разработка и внедрение специальных средств упаковки ценных грузов",
"установка спутниковых датчиков GPS по отслеживанию выполнения маршрута", "приобретение и доукомплектование грузового и легкового автотраспорта"])
#3 регион
risk.append([1.44, 2.83])
marja.append([15.25, 14.49])
costs.append([6.38, 14.59])
names.append(["приобретение и доукомплектование грузового и легкового автотранспорта", "сдача в аренду сторонним организациям части площадей"])
#4 регион
risk.append([1.73, 1.42])
marja.append([13.39, 14.95])
costs.append([13.71, 10.23])
names.append(["приобретение и доукомлектование грузового и легкового автотраспорта", "установка спутниковых датчиков GPS по отслеживанию выполениня маршрута"])
#5 регион
risk.append([1.19, 2.54, 1.51])
marja.append([17.39, 13.18, 13.27])
costs.append([13.16, 12.15, 11.03])
names.append(["закупка запчастей", 
            "реконструкция офисных зданий и сооружений", 
            "приобретение и оборудование бронеатомобилей"])
#6 регион
risk.append([2.57, 2.63])
marja.append([17.05, 16.81])
costs.append([14.95, 11.9])
names.append(["переход на заправки по топливным катрам, отказ от заправок за наличные средства", 
            "установка спутниковых датчиков GPS по отслеживанию выполнения маршрута"])
#7 регион
risk.append([2.24])
marja.append([14.41])
costs.append([6.56])
names.append(["приобретение и оборудование броне автомобилей"])
#8 регион
risk.append([1.05, 1.08, 1.14])
marja.append([13.93, 14.05, 16.41])
costs.append([11.55, 13.69, 11.08])
names.append(["приобретение базы (г.Находка)", "приобретение и доукомплектонание грузового и легкового автотранспорта", 
            "разарботка и внедрение специальных средств упаковки ценных грузов"])

project_in_region=[2, 1, 4, 2, 2, 3, 2, 1, 3] #количество проектов по регионам
regions=9

childs=100 #количество экземпляров в одном
generations=100 #количество поколений

X=[] #пока пустой массив с экземпларами
pokolenie=[] #пустое поколение

up_cost=0 # c+M, надо посчитать
pobeditel=[]

def first_x(): #заполнили поколение случайным образом
    global pokolenie
    for k in range(childs):
        X=[]
        for i in range(regions): #создаем случайный ответ
            pr=[]
            for y in range(project_in_region[i]):
                pr.append(random.randint(0,1))
            X.append(pr)
        pokolenie.append(X)


def fitness(X): #функция определения знаяения целеовй функции (считается прибыль этого варианта)
    max = 0
    for i in range(regions):
        for j in range(len(X[i])):
            # исходная функция, котораю нужно максимизировать
            max = max + X[i][j] * marja[i][j]
    return max

def seek_max(): #функция нахожжедния максимального значеничя ЦФ во всем поколении
    #old_generation=x.copy() #копируем всё поколение
    f_max = 0
    for i in range(childs):
        f = fitness(pokolenie[i])
        if f > f_max:
            f_max = f
    return f_max

def up_limit(): #находим предел затрат, т.е. считаем край бюджета и сохраняем в up_cost
    global up_cost
    up_cost = M
    for i in C:
        up_cost += C[0]

def test_cost(X): #функция определения стоимости реализации особого, т.е. набор сравнитвать это 
    # значение и чтоб не было больше c+M
    s = True
    stoimost=0
    for i in range(regions):
        for j in range(len(X[i])):
            #исходная функция, которую нужно максимизировать
            stoimost = stoimost + X[i][j] * costs[i][j]
    return stoimost

def test_one_project(X): #функция определения наличия хотя бы оддного проекта
    rez = True
    s = 0
    for i in range(regions):
        s = 0
        for j in range(len(X[i])):
            # исходная функция, которую нужно максимизировать
            s = s + X[i][j]
        if s == 0:
            rez = False
    return rez


def new_generation():
    global pokolenie
    old_generation = pokolenie.copy() # копируем всё поколение
    s = seek_max() #находим чемпиона и его значение ЦФ (находим максимальную прибыль в прошлом поколении)
    pokolenie = []
    for i in range(childs): #оставляем все особи, у которых целевая функция больше чем 80% от максимального значение
        if fitness(old_generation[i]) >= 0.8 * s and test_cost(old_generation[i]) <= up_cost and test_one_project(old_generation[i]):
            pokolenie.append(old_generation[i])
    for k in range(childs-len(pokolenie)): #далее дозаполняем случайными значениями
        X = []
        for i in range(regions):
            pr = []
            for y in range(project_in_region[i]):
                pr.append(random.randint(0, 1))
            X.append(pr)
        pokolenie.append(X)


def seek_winner(): #нахождение чемпиона в поколении
    winners = []
    for i in range(childs):
        if fitness(pokolenie[i]) >= seek_max() * 0.5 and test_cost(pokolenie[i]) <= up_cost and test_one_project(pokolenie[i]):
            winners.append([pokolenie[i], fitness(pokolenie[i])])
    max_cf = 0
    for i in winners:
        if i[1] > max_cf:
            return i[0]


up_limit() #находим предел затрат, т.е. считаем край бюджета

first_x() #генерируем случайные значения первого поколения

print(pokolenie[0])

new_generation() #генериреум случайные значения первого поколения


for i in range(generations * 10): #проводим эволючию заданное количество поколений
    new_generation()

w = seek_winner()
print(w) #вывод победителя
print("Прибыль от победителя - ", fitness(w)) #вывод прибыли от победителя, должно быть 246.
print("Затраты на реализацию проектов победителя - ", test_cost(w)) #проверка стоимости реа.
print("Лимит трат на реализацию ", up_cost) #вывод на экран

root = Tk()

out = []
out.append(['Прибыль', 'Риск', 'Стоимость', 'Название проекта', 'ЦФО', 'Одобрен'])

def fill_out(): #заполнение таблицы
    global out
    sum_cost = 0
    sum_marja = 0
    count_project = 0 #число одобренных проектов
    for i in range(regions): # создаем случайный ответ
        out.append(["", "", "", "ЦФО № " + str(i), "", ""])
        for j in range(project_in_region[i]):
            if w[i][j] == 1:
                r = "ДА"
                count_project += 1
                sum_cost += costs[i][j]
                sum_marja += marja[i][j]
            else:
                r = "НЕТ"
            out.append([marja[i][j], risk[i][j], costs[i][j], names[i][j], i, r])
    out.append([str(round(sum_marja, 2)), "", str(round(sum_cost, 2)), "ВСЕГО ОДОБРЕНО "+str(count_project), "", ""])
fill_out()

root.title("Портфель инвестиций")
for i in range(len(out)):
    for j in range(6):
        l = Label(text = str(out[i][j]), relief = RIDGE)
        l.grid(row = i, column = j, sticky = NSEW)

root.mainloop()