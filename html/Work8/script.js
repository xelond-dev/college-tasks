function add() {
    var num1 = parseFloat(document.getElementById("num1").value);
    var num2 = parseFloat(document.getElementById("num2").value);
    var result = num1 + num2;
    document.getElementById("result").innerHTML = "Результат: " + result;
}

function subtract() {
    var num1 = parseFloat(document.getElementById("num1").value);
    var num2 = parseFloat(document.getElementById("num2").value);
    var result = num1 - num2;
    document.getElementById("result").innerHTML = "Результат: " + result;
}

function multiply() {
    var num1 = parseFloat(document.getElementById("num1").value);
    var num2 = parseFloat(document.getElementById("num2").value);
    var result = num1 * num2;
    document.getElementById("result").innerHTML = "Результат: " + result;
}

function divide() {
    var num1 = parseFloat(document.getElementById("num1").value);
    var num2 = parseFloat(document.getElementById("num2").value);
    if (num2 === 0) {
        document.getElementById("result").innerHTML = "Ошибка: деление на ноль";
    } else {
        var result = num1 / num2;
        document.getElementById("result").innerHTML = "Результат: " + result;
    }
}