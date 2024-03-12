package dev.xelond;

import java.util.Scanner;

abstract class Shape {
    abstract double getArea();
    abstract double getPerimeter();

}

class Square extends Shape {
    private final double a;

    public Square(double a) {
        this.a = a;
    }

    double getArea() {
        return a * a;
    }

    double getPerimeter() {
        return a * 4;
    }
}

class Circle extends Shape {
    private final double radius;

    public Circle(double a) {
        this.radius = a;
    }

    double getArea() {
        return Math.PI * radius * radius;
    }

    double getPerimeter() {
        return Math.PI * radius * 2;
    }
}

class Triangle extends Shape {
    private final double a, b, c;

    public Triangle(double a, double b, double c) {
        this.a = a;
        this.b = b;
        this.c = c;
    }

    double getArea() {
        double s = (a + b + c) / 2.0;
        return Math.sqrt(s * (s - a) * (s - b) * (s - c));
    }

    double getPerimeter() {
        return a + b + c;
    }
}



public class Main {
    private static Scanner sc = new Scanner(System.in);

    public static void main(String[] args) {
        System.out.println(" --- Список доступных фигур --- ");
        System.out.println("  1  Квадрат\n  2  Треугольник\n  3  Круг");
        System.out.print("Выберите фигуру: ");
        int shapeNumber = sc.nextInt();

        switch (shapeNumber) {
            case 1:
                System.out.print("Введите сторону квадрата: ");
                double side = sc.nextDouble();

                Square square = new Square(side);
                System.out.println("Периметр квадрата: " + square.getPerimeter() + "\nПлощадь квадрата: " + square.getArea());
                break;

            case 2:
                System.out.print("Введите первую сторону треугольника: ");
                double a = sc.nextDouble();

                System.out.print("Введите вторую сторону треугольника: ");
                double b = sc.nextDouble();

                System.out.print("Введите третью сторону треугольника: ");
                double c = sc.nextDouble();

                Triangle triangle = new Triangle(a, b, c);
                System.out.println("Периметр треугольника: " + triangle.getPerimeter() + "\nПлощадь треугольника: " + triangle.getArea());
                break;

            case 3:
                System.out.print("Введите радиуса круга: ");
                double radius = sc.nextDouble();

                Circle circle = new Circle(radius);
                System.out.println("Периметр круга: " + circle.getPerimeter() + "\nПлощадь круга: " + circle.getArea());
                break;
        }

    }
}