import sqlite3


class Database:
    def __init__(self, db_path="database.db"):
        self.connection = sqlite3.connect(db_path)
        self.cursor = self.connection.cursor()

    def getdata(self, table, datatoget, namedatawehave, datawehave):
        self.cursor.execute(f'SELECT {datatoget} FROM {table} WHERE {namedatawehave} = ?', datawehave)
        return self.cursor.fetchone()

    def getalldata(self, table):
        self.cursor.execute(f'SELECT * FROM {table}')
        return self.cursor.fetchall()

    def writedata(self, table, namedata, datapattern, data):
        self.cursor.execute(f'INSERT INTO {table} {namedata} VALUES {datapattern}', data)
        self.connection.commit()

    def updatedata(self, table, namedatatoupdate, namedatawehave, data):
        self.cursor.execute(f'UPDATE {table} SET {namedatatoupdate} = ? WHERE {namedatawehave} = ?', data)
        self.connection.commit()

    def deletedata(self, table, namedatawehave, datawehave):
        self.cursor.execute(f'DELETE FROM {table} WHERE {namedatawehave} = ?', datawehave)
        self.connection.commit()

# db = Database("database.db")
# db.updatedata(table='addresses', namedatatoupdate='address', namedatawehave='id', data=('г. Донецк', 2))
# db.deletedata(table='addresses', namedatawehave='id', datawehave=(2,))
# print(db.getdata(table='addresses', datatoget='address', namedatawehave='id', datawehave=2))
# db.writedata(table='addresses', namedata='(id, address)', datapattern='(?, ?)', data=(1, "г. Ставрополь"))
