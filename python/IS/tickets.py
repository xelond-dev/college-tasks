import uuid

from db import Database


class Ticket(Database):
    def nameexist(self, name):
        if self.getdata(table='tickets', datatoget='name', namedatawehave='name', datawehave=(name,)) != None:
            return True
        else:
            return False

    def getalltickets(self):
        return self.getalldata('tickets')

    def getid(self, name):
        return self.getdata(table='tickets', datatoget='id', namedatawehave='name', datawehave=(name,))[0]

    def getname(self, id):
        try:
            return self.getdata(table='tickets', datatoget='name', namedatawehave='id', datawehave=(id,))[0]
        except TypeError:
            return ''

    def getcost(self, id):
        return self.getdata(table='tickets', datatoget='cost', namedatawehave='id', datawehave=(id,))[0]

    def getaddressid(self, id):
        return self.getdata(table='tickets', datatoget='addressid', namedatawehave='id', datawehave=(id,))[0]

    def changename(self, id, newname):
        self.updatedata(table='tickets', namedatatoupdate='name', namedatawehave='id', data=(newname, id))

    def changecost(self, id, newcost):
        self.updatedata(table='tickets', namedatatoupdate='cost', namedatawehave='id', data=(newcost, id))

    def changeaddressid(self, id, newaddressid):
        self.updatedata(table='tickets', namedatatoupdate='addressid', namedatawehave='id', data=(newaddressid, id))

    def deleteticket(self, id):
        self.deletedata(table='tickets', namedatawehave='id', datawehave=(id,))

    def createticket(self, name, cost, addressid):
        if self.nameexist(name) == False:
            self.writedata(table='tickets', namedata='(id, name, cost, addressid)', datapattern='(?, ?, ?, ?)', data=(str(uuid.uuid4()), name, cost, addressid))
        else:
            print('Билет уже существует')