from db import Database


class Orders(Database):
    def orderexist(self, username, ticketid):
        self.cursor.execute("SELECT ticketid FROM orders WHERE username = ? AND ticketid = ?", (username, ticketid))
        if self.cursor.fetchone() != None:
            return True
        else:
            return False

    def getallorders(self):
        return self.getalldata('orders')

    def getallticketsbyuser(self, username):
        self.cursor.execute("SELECT ticketid FROM orders WHERE username = ?", (username, ))
        return self.cursor.fetchall()

    def getusername(self, ticketid):
        return self.getdata(table='orders', datatoget='username', namedatawehave='ticketid', datawehave=(ticketid,))[0]

    def deleteorder(self, username, ticketid):
        self.cursor.execute("DELETE FROM orders WHERE username = ? AND ticketid = ?", (username, ticketid))
        self.connection.commit()

    def createorder(self, username, ticketid):
        if self.orderexist(username, ticketid) == False:
            self.writedata(table='orders', namedata='(username, ticketid)', datapattern='(?, ?)', data=(username, ticketid))
        else:
            print('Заказ уже существует')