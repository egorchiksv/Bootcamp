#Html, Css, Jinja
from flask import Flask, render_template  # Flask это фреймворк, который позволяет обрабатывать разные заросы от пользователей
from register import RegisterForm

app = Flask(__name__) # Сохранение приложения в переменную app
app.config['SECRET_KEY'] = 'hello hello hello hello'


def check_password(password):
    if len(password) < 8:
        return 'Длина меньше 8 символов'
    elif password.lower() == password or password.upper() == password:
        return 'Все буквы в одном регистре'
    elif sum([i in password for i in ('1', '2', '3', '4', '5', '6', '7', '8', '9', '0')]) == 0:
        return 'У Вас нет цифр'
    return True


@app.route("/reg", methods=["GET", "POST"])
def register():
    form = RegisterForm()
    if form.validate_on_submit():
        result = check_password(form.data['password'])
        if result != True:
            render_template('reg.html', form=form, message=result)
        redirect('/')
    return render_template("reg.html", form=form)

@app.route("/") # Слеш для главной строницы. Метод GET
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