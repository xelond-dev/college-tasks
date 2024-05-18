let objects = [];
  
  function renderObjects() {
    const container = document.getElementById('objects-container');
    container.innerHTML = '';
  
    objects.forEach(object => {
      const card = `
        <div class="col-md-4 mb-4">
          <div class="card" style="width: 18rem;">
            <img src="${object.imageUrl}" class="card-img-top" alt="${object.name}">
            <div class="card-body">
              <h5 class="card-title">${object.name}</h5>
              <p class="card-text">${object.description}</p>
              <button class="btn btn-primary" onclick="editObject(${object.id})">Изменить</button>
              <button class="btn btn-danger" onclick="deleteObject(${object.id})">Удалить</button>
            </div>
          </div>
        </div>
      `;
      container.innerHTML += card;
    });
  }

  function addObject() {
    const nameInput = document.getElementById('name-input');
    const descriptionInput = document.getElementById('description-input');
    const imageInput = document.getElementById('image-input');
    
    const name = nameInput.value.trim();
    const description = descriptionInput.value.trim();
    const imageUrl = imageInput.value.trim();
    
    if (name && description && imageUrl) {
      const id = objects.length + 1;
      objects.push({ id, name, description, imageUrl });
      renderObjects();
    } else {
      alert("Заполните все поля!");
    }
  }
  
  function deleteObject(id) {
    const index = objects.findIndex(obj => obj.id === id);
    if (index !== -1) {
      objects.splice(index, 1);
      renderObjects();
    }
  }

  function editObject(id) {
    const nameInput = document.getElementById('name-input');
    const descriptionInput = document.getElementById('description-input');
    const imageInput = document.getElementById('image-input');
    
    const name = nameInput.value.trim();
    const description = descriptionInput.value.trim();
    const imageUrl = imageInput.value.trim();
    
    if (name && description && imageUrl) {
      const index = objects.findIndex(obj => obj.id === id);
      if (index !== -1) {
        objects[index] = { id, name, description, imageUrl };
        renderObjects();
      }
    } else {
      alert("Заполните все поля!");
    }
  }