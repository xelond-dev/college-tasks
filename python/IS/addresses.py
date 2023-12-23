import uuid

from db import Database


class Addresses(Database):
    def addressexist(self, address):
        if self.getdata(table='addresses', datatoget='address', namedatawehave='address', datawehave=(address,)) != None:
            return True
        else:
            return False

    def getalladdresses(self):
        return self.getalldata('addresses')

    def getid(self, address):
        return self.getdata(table='addresses', datatoget='id', namedatawehave='address', datawehave=(address,))[0]

    def getaddress(self, id):
        try:
            return self.getdata(table='addresses', datatoget='address', namedatawehave='id', datawehave=(id,))[0]
        except TypeError:
            return ''

    def deleteaddress(self, id):
        self.deletedata(table='addresses', namedatawehave='id', datawehave=(id,))

    def createaddress(self, address):
        if self.addressexist(address) == False:
            self.writedata(table='addresses', namedata='(id, address)', datapattern='(?, ?)', data=(str(uuid.uuid4()), address))
        else:
            print('Адрес уже существует')