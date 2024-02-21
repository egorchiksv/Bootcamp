package com.example;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.nio.charset.StandardCharsets;

public class WebServer {

    public static void main(String[] args) // Метод, с которого начинается программа
    {
        //System.out.println("Hello world!!!"); // Вывод сообщения
        int port = 8088;
        try (ServerSocket serverSocket = new ServerSocket( port)) // Создаем класс с портом для подключения. После выполения этой команды, создается сервер и ожидает подключения по порту
        {
            while (true)
            {
                Socket socket = serverSocket.accept(); // Далее программа останавливается на этой строке и ждет пока к серверу кто-то подключится
                System.out.println("New client connected!"); // Выводим сообщение после того, как к серверу подключились

                BufferedReader input = new BufferedReader( // Считываем не по одному символу, а накапливаем их и потом считываем целую строку
                        new InputStreamReader( //Преобразует байты в символы
                                socket.getInputStream(), StandardCharsets.UTF_8)); // socket.getInputStream() - считываем байты приходящие от подключившегося клиента
                PrintWriter output = new PrintWriter(socket.getOutputStream()); // Запись клиенту, т.е. в браузер

                while (!input.ready()) ;

                while (input.ready())
                {
                    System.out.println(input.readLine());
                }

                output.println("HTTP/1.1 200 OK"); // Вывод сообщения в браузер
                output.println("Content - Type: text/html; charset=utf-8"); // Указываем тип сообщения и кодировку
                output.println(); // Добавляем пустую строку
                output.println("<h1>Привет от сервера!</h1>");
                output.flush(); // Осуществляет отправку информации

                input.close();
                output.close();
            }

        }
        catch (IOException e) // После выполнения этого блока  освобождается порт
        {
            e.printStackTrace();
        }
    }
}
