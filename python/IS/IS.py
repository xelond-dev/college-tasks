import uuid

import user
user_db = user.User()
import tickets
ticket_db = tickets.Ticket()
import orders
orders_db = orders.Orders()
import addresses
addresses_db = addresses.Addresses()

def userpanel():
    print(f'\n\n\n\nДобро пожаловать в магазин продажи билетов на футбольные матчи! \nВыберите что хотите сделать!\n')
    print('[1] - купить билет')
    print('[2] - просмотреть купленые билеты')
    print('[3] - управление аккаунтом')

    panelmanage = 0
    while(panelmanage != 1 and panelmanage != 2 and panelmanage != 3):
        try:
            panelmanage = int(input('Ввод: '))
        except ValueError:
            print('Введите число!')

    match panelmanage:
        case 1:
            usershop()
        case 2:
            userorders()
        case 3:
            manageaccount()

def usershop():
    print(f'\n\nВведите имя билета для покупки. Eсли вы хотите выйти нажмите Enter')
    tickets = ticket_db.getalltickets()
    for row in tickets:
        print(f' - "{row[1]}" Стоимость: {row[2]} руб. Адрес: {addresses_db.getaddress(row[3])}')

    ticketsnamelist = []
    for row in tickets:
        ticketsnamelist.append(row[1])
    current_ticket = '1'
    while(current_ticket not in ticketsnamelist and current_ticket != ''):
        current_ticket = input('Ввод: ')

    if current_ticket == '':
        userpanel()
    for row in tickets:
        if row[1] == current_ticket:
            current_ticket = row
    if orders_db.orderexist(username, current_ticket[0]):
        print('Вы уже купили этот билет! Нажмите Enter чтобы купить другой.')
        input()
        usershop()
    else:
        orders_db.createorder(username, current_ticket[0])

    print(f'Вы купили билет {current_ticket[1]} за {current_ticket[2]} руб! Спасибо за покупку! \nНажмите Enter для выхода в главное меню.')
    input()
    userpanel()


def userorders():
    orders = orders_db.getallticketsbyuser(username)
    if orders == []:
        print('У вас не обнаружено билетов. Нажмите Enter для выхода в главное меню.')
        input()
        userpanel()
    print(f'\n\nВот список купленных вами билетов. Eсли вы хотите вернутся обратно нажмите Enter, а если хотите вернуть деньги за билет то введите его название.')
    tickets = []
    for row in orders:
        tickets.append(row[0])
    for row in tickets:
        print(f' - "{ticket_db.getname(row)}" Адрес: {addresses_db.getaddress(ticket_db.getaddressid(row))}')

    ticketsnamelist = []
    for row in tickets:
        ticketsnamelist.append(ticket_db.getname(row))
    current_ticket = '1'
    while (current_ticket not in ticketsnamelist and current_ticket != ''):
        current_ticket = input('Ввод: ')

    if current_ticket == '':
        userpanel()
    else:
        orders_db.deleteorder(username, ticket_db.getid(current_ticket))
        print(f'Вы успешно отменили билет "{current_ticket}". \nНажмите Enter для выхода в главное меню.')
        input()
        userpanel()


def manageaccount():
    print(f'\n\nУправление аккаунтом. \nВыберите что хотите сделать!\n')
    print('[1] - сменить имя.')
    print('[2] - сменить пароль.')

    panelmanage = 0
    while (panelmanage != 1 and panelmanage != 2):
        try:
            panelmanage = int(input('Ввод: '))
        except ValueError:
            print('Введите число!')

    match panelmanage:
        case 1:
            changeusername(username)
        case 2:
            changepassword(username)

def changeusername(oldusername):
    print('Какое имя вы хотите выбрать?')
    username = str(input("Ввод: "))
    if user_db.nameexist(username) == True:
        print('Имя пользователя уже зарегестрировано!')

    while (user_db.nameexist(username) == True):
        username = str(input("Ввод: "))
        if user_db.nameexist(username) == True:
            print('Имя пользователя уже зарегестрировано!')

    user_db.changename(oldusername, username)
    print(f'Имя пользователя было изменено с "{oldusername}" на "{username}"')
    if role == 'user':
        print('Нажмите Enter чтобы продолжить.')
        input()
        userpanel()
    else:
        print('Нажмите Enter чтобы продолжить.')
        input()
        adminpanel()

def changepassword(username):
    print('Введите новый пароль.')
    password = ''
    while (len(password) < 8):
        password = str(input("Ввод: "))
        if len(password) < 8:
            print('Пароль меньше 8 символов!')
    user_db.changepassword(username, password)
    print(f'Пароль пользователя был изменен.')
    if role == 'user':
        print('В связи с изменением пароля, вам прийдется ввойсти в аккаунт заново путем завершения программы. Нажмите Enter чтобы продолжить.')
        input()
        exit(0)
    else:
        print('Нажмите Enter чтобы продолжить.')
        input()
        adminpanel()



def adminpanel():
    print(f'\n\n\n\nДобро пожаловать в панель управления админимтратора \nВыберите что хотите сделать!\n')
    print('[1] - изменить данные таблицы users')
    print('[2] - изменить данные таблицы tickets')
    print('[3] - изменить данные таблицы orders')
    print('[4] - изменить данные таблицы addresses')

    panelmanage = 0
    while (panelmanage != 1 and panelmanage != 2 and panelmanage != 3 and panelmanage != 4):
        try:
            panelmanage = int(input('Ввод: '))
        except ValueError:
            print('Введите число!')

    match panelmanage:
        case 1:
            usersmanage()
        case 2:
            ticketsmanage()
        case 3:
            ordersmanage()
        case 4:
            addressesmanage()

def usersmanage():
    print('\n\nВведите имя пользователя, которого хотите изменить или введите create для создания нового. Нажмите Enter чтобы выйти.')
    users = user_db.getallusers()
    for row in users:
        print(f'name: {row[0]}, password: {row[1]}, role: {row[2]}')

    usersnamelist = []
    for row in users:
        usersnamelist.append(row[0])
    current_user = '`'
    while (current_user not in usersnamelist and current_user != '' and current_user != 'create'):
        current_user = input('Ввод: ')

    if current_user == '':
        adminpanel()
    if current_user == 'create':
        print('Введите данные нового пользователя через запятую в порядке: name, password, role')
        decision = False
        data = []
        while(decision == False):
            data = list(input('Ввод: ').split(','))
            try:
                if user_db.nameexist(data[0]) == True:
                    print('Имя пользователя уже зарегестрирован!')
                elif len(data[1]) < 8:
                    print('Пароль меньше 8 символов!')
                elif data[2] != 'user' and data[2] != 'admin':
                    print('Недопустимая роль! Допустимые имена "user", "admin"')
                else:
                    decision = True
            except IndexError:
                print('Введите все значения!')
        user_db.createuser(data[0], data[1], data[2])
        print(f'Был создан пользователь {data[0]}. Нажмите Enter чтобы продолжить.')
        input()
        adminpanel()

    for row in users:
        if row[0] == current_user:
            current_user = row

    print(f'\nВы выбрали пользователя "{current_user[0]}" Выберите то, что вы хотите изменить.')
    print('[1] - изменить name')
    print('[2] - изменить password')
    print('[3] - изменить role')
    print('[4] - удалить пользователя')

    panelmanage = 0
    while (panelmanage != 1 and panelmanage != 2 and panelmanage != 3 and panelmanage != 4):
        try:
            panelmanage = int(input('Ввод: '))
        except ValueError:
            print('Введите число!')

    match panelmanage:
        case 1:
            changeusername(current_user[0])
        case 2:
            changepassword(current_user[0])
        case 3:
            print('Какую роль вы хотите присвоить?')
            print('[1] - user')
            print('[2] - admin')

            panelmanage = 0
            while (panelmanage != 1 and panelmanage != 2):
                try:
                    panelmanage = int(input('Ввод: '))
                except ValueError:
                    print('Введите число!')
            match panelmanage:
                case 1:
                    panelmanage = 'user'
                case 2:
                    panelmanage = 'admin'

            user_db.changerole(username, panelmanage)
            print(f'Роль пользователя "{username}" была изменена на "{panelmanage}" \nНажмите Enter чтобы продолжить.')
            input()
            adminpanel()
        case 4:
            user_db.deleteuser(current_user[0])
            print(f'Пользователь "{username}" был удален \nНажмите Enter чтобы продолжить.')
            input()
            adminpanel()

def ticketsmanage():
    print('\n\nВведите id билета, который хотите изменить или введите create для создания нового. Нажмите Enter чтобы выйти.')
    tickets = ticket_db.getalltickets()
    for row in tickets:
        print(f'id: {row[0]}, name: {row[1]}, cost: {row[2]}, addressid: {row[3]}')

    ticketsidlist = []
    for row in tickets:
        ticketsidlist.append(str(row[0]))
    current_ticket = '`'
    while (current_ticket not in ticketsidlist and current_ticket != '' and current_ticket != 'create'):
        current_ticket = input('Ввод: ')

    if current_ticket == '':
        adminpanel()
    if current_ticket == 'create':
        print('Введите данные нового билета через запятую в порядке: name, cost, addressid (id создается автоматически)')
        decision = False
        data = []
        while(decision == False):
            data = list(input('Ввод: ').split(','))
            try:
                if float(data[1]) <= 0:
                    print('Стоимость не может быть меньше или равна 0')
                elif addresses_db.addressexist(addresses_db.getaddress(data[2])) == False:
                    print('Введите id существующего адреса')
                else:
                    decision = True
            except IndexError:
                print('Введите все значения!')
            except ValueError:
                print('Стоимость должна быть указана цифрами')
        ticket_db.createticket(data[0], data[1], data[2])
        print(f'Был создан билет {data[0]}. Нажмите Enter чтобы продолжить.')
        input()
        adminpanel()

    for row in tickets:
        if row[0] == current_ticket:
            current_ticket = row

    print(f'\nВы выбрали пользователя "{current_ticket[0]}" Выберите то, что вы хотите изменить.')
    print('[1] - изменить name')
    print('[2] - изменить cost')
    print('[3] - изменить addressid')
    print('[4] - удалить билет')

    panelmanage = 0
    while (panelmanage != 1 and panelmanage != 2 and panelmanage != 3 and panelmanage != 4):
        try:
            panelmanage = int(input('Ввод: '))
        except ValueError:
            print('Введите число!')

    match panelmanage:
        case 1:
            print('Введите новое имя.')
            name = ''
            while name == '':
                name = str(input("Ввод: "))
            ticket_db.changename(current_ticket[0], name)
            print('Имя билета было изменено.\nНажмите Enter чтобы продолжить')
            input()
            adminpanel()
        case 2:
            print('Введите новую стоимость товара.')
            cost = 0
            while cost <= 0:
                try:
                    cost = float(input("Ввод: "))
                    if cost <= 0:
                        print('Стоимость не может быть меньше или равна 0')
                except ValueError:
                    print('Стоимость должна быть указана цифрами')
            ticket_db.changecost(current_ticket[0], cost)
            print('Стоиость билета была изменена.\nНажмите Enter чтобы продолжить')
            input()
            adminpanel()
        case 3:
            print('Введите новый addressid.')
            id = '`'
            while addresses_db.addressexist(addresses_db.getaddress(id)) == False:
                id = input("Ввод: ")
                if addresses_db.addressexist(addresses_db.getaddress(id)) == False:
                    print('Введите id существующего адреса')

            ticket_db.changeaddressid(current_ticket[0], id)
            print('Addressid билета был изменен.\nНажмите Enter чтобы продолжить')
            input()
            adminpanel()
        case 4:
            ticket_db.deleteticket(current_ticket[0])
            print(f'Билет был удален \nНажмите Enter чтобы продолжить.')
            input()
            adminpanel()

def ordersmanage():
    print('\n\nВведите имя пользователя для вывода отфильрованного списка заказов или введите create для создания нового заказа. Нажмите Enter чтобы выйти.')
    orders = orders_db.getallorders()
    for row in orders:
        print(f'username: {row[0]}, ticketid: {row[1]}')

    ordersnamelist = []
    for row in orders:
        ordersnamelist.append(str(row[0]))
    current_username_order = '`'
    while (current_username_order not in ordersnamelist and current_username_order != '' and current_username_order != 'create'):
        current_username_order = input('Ввод: ')

    if current_username_order == '':
        adminpanel()
    elif current_username_order == 'create':
        print('\nВведите имя пользователя, на которое вы хотите заказать билет')
        username = ''
        while(user_db.nameexist(username) == False):
            username = input('Ввод: ')
        print('\nВведите ticketid билета')
        ticketid = ''
        while (ticket_db.nameexist(ticket_db.getname(ticketid)) == False):
            ticketid = input('Ввод: ')
        orders_db.createorder(username, ticketid)
        print(f'\nВы заказали билет {ticketid} на имя {username} \nНажмите Enter чтобы выйти')
        input()
        adminpanel()

    orders = orders_db.getallticketsbyuser(current_username_order)
    print('\nВведите ticketid того заказа, который хотите удалить или нажмите Enter чтобы выйти')
    for row in orders:
        print(f'username: {current_username_order}, ticketid: {row[0]}')

    id = '`'
    ordersidlist = []
    for row in orders:
        ordersidlist.append(str(row[0]))
    while (id not in ordersidlist and id != ''):
        id = str(input('Ввод: '))
    if id == '':
        adminpanel()
    orders_db.deleteorder(current_username_order, id)
    print(f'Заказ был удален \nНажмите Enter чтобы продолжить.')
    input()
    adminpanel()

def addressesmanage():
    print('\n\nВведите id адреса, который хотите удалить или введите create для создания нового адреса. Нажмите Enter чтобы выйти.')
    addresses = addresses_db.getalladdresses()
    for row in addresses:
        print(f'id: {row[0]}, address: {row[1]}')

    addressesidlist = []
    for row in addresses:
        addressesidlist.append(str(row[0]))
    current_address = '`'
    while (current_address not in addressesidlist and current_address != '' and current_address != 'create'):
        current_address = str(input('Ввод: '))

    if current_address == '':
        adminpanel()
    elif current_address == 'create':
        print('\nВведите адрес (id сгенерируется автоматически)')
        address = ''
        while(address == ''):
            address = str(input('Ввод: '))
        addresses_db.createaddress(address)
        print(f'\nВы создали новую запись об адресе {address} \nНажмите Enter чтобы выйти')
        input()
        adminpanel()

    addresses_db.deleteaddress(current_address)
    print(f'Адрес был удален \nНажмите Enter чтобы продолжить.')
    input()
    adminpanel()

print(f'Добро пожаловать в магазин продажи билетов на футбольный матч \nВведите 1 если вый хотите войти в существующий аккаунт, введите 2 если хотите зарегестрировать новый')
registerchoise = None
while (registerchoise != 1 and registerchoise != 2):
            try:
                registerchoise = int(input("Ввод: "))
            except ValueError:
                print("Пожалуйста, введите число от 1 или 2.")
username = ""
password = ""
role = ""
if registerchoise == 2:
    print('Придумайте имя пользователя!')
    username = str(input("Ввод: "))
    if user_db.nameexist(username) == True:
        print('Имя пользователя уже зарегестрировано!')

    while (user_db.nameexist(username) == True):
        username = str(input("Ввод: "))
        if user_db.nameexist(username) == True:
            print('Имя пользователя уже зарегестрировано!')

    print('Придумайте пароль! (от 8 символов)')
    while (len(password) < 8):
        password = str(input("Ввод: "))
        if len(password) < 8:
            print('Пароль меньше 8 символов!')
    user_db.createuser(username,password, 'user')
    registerchoise = 1
    print(f'Вы успешно зарегестрировались как "{username}" под ролью "user" \nТеперь используйте свой логин и пароль для входа в аккаунт')
    username = ""
    password = ""

if registerchoise == 1:
    print(f'Вы решили войти \nВведите имя пользователя!')
    while(user_db.nameexist(username) == False):
        username = str(input("Ввод: "))
        if user_db.nameexist(username) == False:
            print('Аккаунта не сущетсвует!')

    print(f'Введите пароль.')
    while(user_db.getpassword(username) != password):
        password = str(input("Ввод: "))
        if user_db.getpassword(username) != password:
            print('Неверный пароль!')
    role = user_db.getrole(username)
    print(f'Вы успешно вошли как "{username}" под ролью "{role}"')
    match role:
        case 'user':
            userpanel()
        case 'admin':
            adminpanel()




