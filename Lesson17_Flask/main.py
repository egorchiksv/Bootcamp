#Html, Css, Jinja
from flask import Flask, render_template  # Flask это фреймворк, который позволяет обрабатывать разные заросы от пользователей


app = Flask(__name__) # Сохранение приложения в переменную app

# https://ya.ru
@app.route("/") # Слеш для главной строницы
def index(): # Создание функции
    return render_template('base.html', title = "Главная страница 2.0") # Передаем html документ из папки templates

@app.route('/stud')
def student():
    list_student =  ['Кирилл Тетюев', 'Евгений Сожевский', 'Нистрян Даниел', 
                     'Андрей Коротий', 'Нистрян Даниел', 'Мардан Адилханов',
                     'Аслан Аксиров', ]
    return render_template('student.html', title='Список студентов',
                            data=list_student)




@app.route("/info") # Декоратор или обработчик событий
def info():
    return "<h3>Сайт создан компанией GeekBrains</h3>"



@app.route("/calc/<int:x>/<int:y>") # Передаем параметры x и y в url
def calc(x, y):
    return f'{x} + {y} = {x + y}'


@app.route("/hi/<name>") # Передаем параметры x и y в url
def hello(name):
    return f'Hello, {name}!'


if __name__ == "__main__": # Проверка если программный код запущен из файла main, то ошибки не будет. Это сделано, 
                           # чтобы злоумышленники не смогли запускать код извне. main это не название файла, а специальная строка, которая говорит, что запущен из текущего файла
    app.run()