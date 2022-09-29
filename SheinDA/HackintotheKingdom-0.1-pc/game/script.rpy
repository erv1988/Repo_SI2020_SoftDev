# Вы можете расположить сценарий своей игры в этом файле.

# Определение персонажей игры.
define jay = Character('Джейден', color="#eec8ff")

# Вместо использования оператора image можете просто
# складывать все ваши файлы изображений в папку images.
# Например, сцену bg room можно вызвать файлом "bg room.png",
# а eileen happy — "eileen happy.webp", и тогда они появятся в игре.

# Игра начинается здесь:
label start:

    scene bg room

    show eileen happy

    jay "Добро пожловать в Hack into the Kingodm!"

    jay "здесь пока что ничего нет, да и я буду выглядеть совсем иначе."

    jay "Как ты считаешь, что такое \"Визульная новелла\"?"

menu:
        "Это игра":
            jump test1

        "Это интерактивная книга":
            jump test2

label test1:

    jay "Тогда удачи с погружением в игровой мир \"Hack into the Kingdom\"."

    jump next 

label test2:

    jay "Тогда надеюсь, что сюжет \"Hack into the Kingdom\" будет интересным."

    jump next 

label next:

    jay "Скоро увидимся ;)"


    return
