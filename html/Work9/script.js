let cars = [];

function addCar(event) {
  event.preventDefault();
  const brandInput = document.getElementById('brand');
  const modelInput = document.getElementById('model');
  const yearInput = document.getElementById('year');
  const imageUrlInput = document.getElementById('imageUrl');

  const brand = brandInput.value.trim();
  const model = modelInput.value.trim();
  const year = parseInt(yearInput.value.trim());
  const imageUrl = imageUrlInput.value.trim();

  if (!brand || !model || !year || isNaN(year)) {
    alert('Пожалуйста, заполните все поля корректно.');
    return;
  }

  const car = { brand, model, year, imageUrl };
  cars.push(car);
  displayCars();
}

function displayCars() {
  const carList = document.getElementById('car-list');
  carList.innerHTML = '';

  cars.forEach((car, index) => {
    const li = document.createElement('li');
    li.innerHTML = 
        `<strong>${car.brand}</strong> ${car.model}, ${car.year}
        <img src="${car.imageUrl}" alt="${car.brand} ${car.model}">
        <button onclick="deleteCar(${index})">Удалить</button>
        <button onclick="editCar(${index})">Изменить</button>`
    ;
    carList.appendChild(li);
  });
}

function editCar(index) {
    const car = cars[index];
    const brandInput = document.getElementById('brand');
    const modelInput = document.getElementById('model');
    const yearInput = document.getElementById('year');
    const imageUrlInput = document.getElementById('imageUrl');
    car.brand = brandInput.value;
    car.model = modelInput.value;
    car.year = yearInput.value;
    car.imageUrl = imageUrlInput.value;
    displayCars();
  }


function deleteCar(index) {
  cars.splice(index, 1);
  displayCars();
}

const form = document.getElementById('car-form');
form.addEventListener('submit', addCar);