interface Animal {
    void eat();
    void sound();
}

class Dog implements Animal {
    @Override
    public void eat() {
        System.out.println("Собака ест кость");
    }
    @Override
    public void sound() {
        System.out.println("Гав");
    }
}

class Cat implements Animal {
    @Override
    public void eat() {
        System.out.println("Кошка ест рыбу");
    }
    @Override
    public void sound() {
        System.out.println("Мяу");
    }
}

interface Pet extends Animal {
    void play();
}

class DogPet extends Dog implements Pet {
    @Override
    public void play() {
        System.out.println("Собака играет с мячом");
    }
}

class CatPet extends Cat implements Pet {
    @Override
    public void play() {
        System.out.println("Кошка играет с веревочкой");
    }
}

public class Main {
    public static void main(String[] args) {
        DogPet dog = new DogPet();
        CatPet cat = new CatPet();
        dog.eat();
        dog.sound();
        dog.play();
        cat.eat();
        cat.sound();
        cat.play();
    }
}
