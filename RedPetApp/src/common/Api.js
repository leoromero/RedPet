class Service {
    constructor(id, name, description, iconname)
    {
        this.id = id,
        this.name = name,
        this.description = description,
        this.iconname = iconname
    };
}

class Product {
    constructor(id, name, description, iconname)
    {
        this.id = id,
        this.name = name,
        this.description = description,
        this.iconname = iconname
    };
}

class Promotion {
    constructor(id, name, description, iconname)
    {
        this.id = id,
        this.name = name,
        this.description = description,
        this.iconname = iconname
    };}

class User {
    constructor(id, username, pets, address)
    {
        this.id = id,
        this.username = username,
        this.pets = pets,
        this.address = address
    }
};

class Pet {
    constructor(id, name, type)
    {
        this.id = id,
        this.name = name,
        this.type = type
    }
};

class Breed {
    constructor(id, name)
    {
        this.id = id,
        this.name = name
    }
};

class Size {
    constructor(id, name)
    {
        this.id = id,
        this.name = name
    }
};

var services = [
    new Service(1, 'Guarderia', 'Deja a tu mascota bajo el cuidado de un profesional, tu mascota sera cuidada, alimentada y entretenida durante las horas requeridas.', 'icon' ),
    new Service(2, 'Peluqueria', '¿Quieres hacerle un cambio de look, el corte de la raza, un mantenimiento, o un teñido a tu mascota? En el servicio de peluqueria vas a encontrar todo lo que necesitas.', 'icon'),
];
var products = [
    new Product(1, 'Comida Doggy 123', 'comida para perro marca X tipo Y.', 'icon'),
    new Product(2, 'Comida Pedigree 123', 'comida para perro marca X tipo Y.', 'icon'),
];
var promotions = [
    new Promotion(1,'Promoción 1', '15 paseos + 10kg de comida.', 'icon')
];

var pets = [
    new Pet(1, 'Ramon', 'Border Coly'),
    new Pet(2, 'Lara', 'Cocker')
];

var breeds = [
    new Breed(1, 'Cocker'),
    new Breed(2, 'Dogo'),
    new Breed(3, 'Labrador'),
    new Breed(4, 'Dalmata'),
    new Breed(5, 'Golden')
];

var sizes = [
    new Size(1, 'Chico'),
    new Size(2, 'Mediano'),
    new Size(3, 'Grande')
];

var user = new User(1, 'leo', pets, 'Pablo suarez 123 esq. Eloy Alfaro');

export default {
    services(url) {
        return {
          getOne: (id) => services.find(s => s.id == id),
          getAll: () => services,
          update: (toUpdate) =>  axios.put(url,toUpdate),
          create: (toCreate) =>  axios.put(url,toCreate),
          delete: ({ id }) =>  axios.delete(`${url}/${id}`)
        }
      },
      products(url){
          return {
            getOne: (id) => products.find(s => s.id == id),
            getAll: () => products,
            update: (toUpdate) =>  axios.put(url,toUpdate),
            create: (toCreate) =>  axios.put(url,toCreate),
            delete: ({ id }) =>  axios.delete(`${url}/${id}`)
          }
      },
      promotions(url){
        return {
            getOne: (id) => promotions.find(s => s.id == id),
            getAll: () => promotions,
            update: (toUpdate) =>  axios.put(url,toUpdate),
            create: (toCreate) =>  axios.put(url,toCreate),
            delete: ({ id }) =>  axios.delete(`${url}/${id}`)
          }
      },
      loggedUser(){
          return user;
      },
      breeds(){
          console.log(breeds);
          return breeds;
      },
      sizes(){
          return sizes;
      }
    }