#Очереди задач (Redis)
import redis
import random

with redis.Redis() as redis_server:#Созадем сервер из нашего подключения Redis. Открываем соединение, потом само соединение закрывается
    redis_server.lpush("queue", random.randint(0, 10))