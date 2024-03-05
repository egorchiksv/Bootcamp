#Очереди задач (Redis) клиент
import redis

with redis.Redis() as redis_client:
    value = redis_client.brpop("queue") # Команда brpop ждет данные из очереди, если данных в этой очереди нет

print(int(value[1]))