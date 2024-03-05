#Post, Get, Создание форм
from flask_wtf import FlaskForm
from wtforms import StringField, SubmitField, PasswordField, EmailField
from wtforms.validators import DataRequired

class RegisterForm(FlaskForm):
    name = StringField("Имя: ", validators=[DataRequired()])
    email = EmailField("Почта: ", validators=[DataRequired()])
    password = PasswordField("Пароль: ", validators=[DataRequired()])
    submit = SubmitField("Отправить")
