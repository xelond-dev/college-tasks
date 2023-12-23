from db import Database


class User(Database):
    def nameexist(self, name):
        if self.getdata(table='users', datatoget='name', namedatawehave='name', datawehave=(name,)) != None:
            return True
        else:
            return False

    def getpassword(self, name):
        return self.getdata(table='users', datatoget='password', namedatawehave='name', datawehave=(name,))[0]

    def getallusers(self):
        return self.getalldata('users')

    def getrole(self, name):
        return self.getdata(table='users', datatoget='role', namedatawehave='name', datawehave=(name,))[0]

    def changename(self, name, newname):
        self.updatedata(table='users', namedatatoupdate='name', namedatawehave='name', data=(newname, name))

    def changepassword(self, name, newpassword):
        self.updatedata(table='users', namedatatoupdate='password', namedatawehave='name', data=(newpassword, name))

    def changerole(self, name, newrole):
        self.updatedata(table='users', namedatatoupdate='role', namedatawehave='name', data=(newrole, name))

    def deleteuser(self, name):
        self.deletedata(table='users', namedatawehave='name', datawehave=(name,))

    def createuser(self, name, password, role):
        if self.nameexist(name) == False:
            self.writedata(table='users', namedata='(name, password, role)', datapattern='(?, ?, ?)', data=(name, password, role))
        else:
            print('Пользователь уже существует')