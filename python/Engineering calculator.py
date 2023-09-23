import math


class calculator():
    def __init__(self):
        while(True):
            try:
                first = float(input("Введите число: "))                
                operation = input("Выберите операцию (+, -, *, /, **, sqr, fac, sin, cos, tan): ")
                
                if (operation != "sqr" and operation != "fac" and operation != "sin" and operation != "cos"):
                    second = float(input("Введите второе число: "))

                match(operation):
                    case "+":
                        print("Ответ: ", first+second)
                    case "-":
                        print("Ответ: ", first-second)
                    case "*":
                        print("Ответ: ", first*second)
                    case "/":
                        print("Ответ: ", first/second)
                    case "**":
                        print("Ответ: ", first**second)
                    case "sqr":
                        print("Ответ: ", first**0.5)
                    case "fac":
                        print("Ответ: ", math.factorial(first))
                    case "sin":
                        print("Ответ: ", math.sin(first))
                    case "cos":
                        print("Ответ: ", math.cos(first))
                    case "tan":
                        print("Ответ: ", math.tan(first))
                    case _:
                        print("Операция выбрана не верно.")

                # if (operation == "+"):
                #     print("Ответ: ", first+second)
                # elif (operation == "-"):
                #     print("Ответ: ", first-second)
                # elif (operation == "*"):
                #     print("Ответ: ", first*second)
                # elif (operation == "/"):
                #     print("Ответ: ", first/second)
                # elif (operation == "**"):
                #     print("Ответ: ", first**second)
                # elif (operation == "sqr"):
                #     print("Ответ: ", first**0.5)
                # elif (operation == "fac"):
                #     print("Ответ: ", math.factorial(int(first)))
                # elif (operation == "sin"):
                #     print("Ответ: ", math.sin(first))
                # elif (operation == "cos"):
                #     print("Ответ: ", math.cos(first))
                # elif (operation == "tan"):
                #     print("Ответ: ", math.tan(first))
                # else:
                #     print("Операция выбрана не верно.")
            
            except ValueError:
                print("Значения введены не верно.")
            except ZeroDivisionError:
                print("Невозможно делить на 0.")
            except KeyboardInterrupt:
                print("\nВыход..")
                exit(0)
            
            first, second, operation = None, None, None
            print("\n")


calculator()
