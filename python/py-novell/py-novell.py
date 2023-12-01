import os, time
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

    

display_text("Утро.", end_time=2)

#call_alarm(3)
#call_alarm(3)


display_text("* Вы просыпаетесь от настойчивого звонка будильника.")

#call_alarm(3, end_time=0)

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


display_text("Вы собираетесь и идете на пару.")
display_text("")