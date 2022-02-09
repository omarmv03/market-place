export interface IProducto {
    id: number;
    descripcion: string;
    imagen: string;
    precio: number;
    titulo: string;
    cantidadPedida: number;
}

export class Producto implements IProducto {
    id: number;
    descripcion: string;
    imagen: string;
    precio: number;
    titulo: string;
    cantidadPedida: number;
    /**
     *
     */
    constructor(p: IProducto) {
        this.id = p.id;
        this.descripcion = p.descripcion;
        this.imagen = p.imagen;
        this.precio = p.precio;
        this.titulo = p.titulo;
        this.cantidadPedida = p.cantidadPedida;        
    }
}