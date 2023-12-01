import os, time, random
import json
import beepy


def display_text(message, sleep_time=0.04, end_time=0, pause=False):
    for i in message:
        #time.sleep(sleep_time)
        print(i, end='', flush=True)
    
    #time.sleep(end_time)
    if (pause):
        #time.sleep(1)
        input(" [Далее (Enter)] ")
    print()


def call_alarm(sound_counter, end_time=1):
    for i in range(sound_counter):
        beepy.beep(3)
    time.sleep(end_time)

def mobile_notify(type, end_time = 1):
    if type == "call":
        beepy.beep(3)
    elif type == "notify":
        beepy.beep(3)

    time.sleep(end_time)


def user_choice(choices):
    user_choice = -1
    
    while (user_choice > len(choices) or user_choice < 1):
        i = 1
        
        print("\n")

        for choice in choices:
            print(f"[{i}] {choice}")
            i += 1

        user_choice = int(input())

    return user_choice

def read_json():
    with open('data.json', 'r') as file:
        data = json.load(file)
    return data

def write_json(data):
    with open('data.json', 'r') as file:
        json.dump(data, file, indent=4)

def append_json(data):
    exist_data = read_json()
    exist_data.update(data)
    write_json(exist_data)

display_text("Утро.", end_time=2)

call_alarm(3)
call_alarm(3)


display_text("* Вы просыпаетесь от настойчивого звонка будильника.")

call_alarm(2, end_time=0)

display_text("- Да завались ты уже.", sleep_time=0.02, end_time=2)
display_text("* Вы выключаете будильник. *", end_time=2)
display_text("* На минуту вы закрываете глаза. *", end_time=2)

mobile_notify("notifiy")

display_text("** Новое сообщение **", sleep_time=0, pause=True)
display_text("Вы неохотно поднимаете телефон.")

display_text("Настя: Тебя где носит?")
display_text("Настя: У нас пара идет уже как 30 минут")

display_text("- Бл*ть..")

choices = [
    "Вы -> Настя: Уже иду..",
    "Вы -> Настя: Есть ли смысл вообще приходить?",
    "* Проигнорировать *"
]

choice_user = user_choice(choices)

if (choice_user == 1):
    display_text("Настя: Давай бегом")
elif (choice_user == 2):
    display_text("Настя: Тебя препод спросить хочет, сегодня же последний день")
    display_text("Настя: Иначе, обещает лишить тебя автомата")
    
    choices = [
        "Вы -> Настя: Ладно, понял",
        "Вы -> Настя: Ты можешь попробовать договорится?",
        "* Проигнорировать *"
    ]

    choice_user = user_choice(choices)

    if (choice_user == 1):
        display_text("Настя: Давай бегом.")
    elif (choice_user == 2):
        display_text("Ага, щас.")
    elif (choice_user == 3):
        display_text("* Вы решаете проигнорировать Настю. *")

elif (choice_user == 3):
    display_text("* Вы решаете проигнорировать Настю. *")

display_text("- Ну вот и что мне делать?")

choices = [
    "* Собраться и появится на паре. *",
    "* Остаться в кровати и лечь спать. *",
]

choice_user = user_choice(choices)

if (choice_user == 2):
    display_text("Вы решаете остаться дома и ложитесь спать.", end_time = 3)
    mobile_notify("call", end_time = 2)

    display_text("** Звонок от Насти **")
    display_text("* Вы отвечаете на звонок. *")

    display_text("- Ты не появился на 4-ех предметах в последнии пары")
    display_text("- Тебе сказали подойти и забрать документы", end_time = 3)
    display_text("- Доволен?")

    display_text("< Плохай концовка. >")

    exit(0)

display_text("Собираясь, вы увидили на столе билеты к вашему предмету.")
choices = [
    "Выучить 1-ый билет",
    "Выучить 2-ый билет",
    "Выучить 3-ый билет",
    "* Проигнорировать *"
]

teach_ticket = user_choice(choices)

display_text("Вы собираетесь и идете на пару.", end_time = 3)

display_text("Вы сидите на паре и стараетесь не привлекать внимания.")
display_text("И последний, кто ответит сегодня, это..")
display_text("* Вы начинаете переживать *")

choices = [
    "* Перебить преподователя и отпросится в туалет. *",
    "* Надеется на лучшее. *",
]

choice_user = user_choice(choices)

if (choice_user == 1):
    display_text("- Извините пожалуйста, можно выйти?..")
    display_text("* В аудитории наростает гробовая тишина. *")

    random_ask = random.randint(1, 2)

    if (random_ask == 2):
        display_text("- Выйдите, если вам приспичело.")
        display_text("< Положительный выбор >")
        display_text("< Хорошая концовка >")
        exit(0)

    display_text("- Думаю, что вы мне и ответите, Лукьянов.")
    display_text("< Отрицательный выбор >")

    display_text("* Вы понимаете, что ваш план не сработал. *")
    
    random_ask = random.randint(1, 2)

    if (random_ask == 1):
        display_text("И так, думаю что вы ответите мне билет под номером..")
        display_text(f"..билет номер {teach_ticket}.")
        display_text("< Положительный выбор >")
        display_text("Вы ответили на все вопросы преподователя и получили зачет.")
        display_text("< Хорошая концовка >")
        exit(0)
    else:
        display_text(f"..билет номер {teach_ticket + 1}.")
        display_text("< Отрицательный выбор >")

        display_text("К сожалению, вы не смогли ответить на билеты.")
        display_text("< Плохая концовка >")
        exit(0)