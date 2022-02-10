import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IProducto, Producto } from 'src/app/model/producto';
import { ProductsService } from 'src/app/services/products.service';
import { fileSizeValidator } from 'src/app/validators/fileSize.validator';
import { requiredFileType } from 'src/app/validators/requiredFileType.validator';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.scss']
})
export class EditProductComponent implements OnInit {

  imageURL!: string;
  formProduct: FormGroup;
  id!: string | null;
  product!: IProducto | undefined;
  submit = false;

  get f() { return this.formProduct.controls; }

  constructor(private route: ActivatedRoute,
    private productService: ProductsService,
    private formBuilder: FormBuilder) {
      
    this.formProduct = this.formBuilder.group({
      titulo: ['', [Validators.required, Validators.maxLength(30)]],
      id: [''],
      descripcion: ['', [Validators.required, Validators.maxLength(50)]],
      precio: ['', [Validators.required, Validators.maxLength(10)]],
      imagen: ['', [Validators.required]],
      file: []
    });
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.productService.get().subscribe((x: IProducto[]) => {
      this.product = x.find(f => f.id.toString() == this.id);
      if (this.product) {
        this.imageURL = this.product.imagen;
        this.product.imagen = '';
        this.formProduct.patchValue(this.product);
      }
    });
  }

  onFileChange(event: any) {
    let reader = new FileReader();

    this.formProduct.controls.imagen.setValidators([fileSizeValidator(event.target.files),
                                                      Validators.required,
                                                      requiredFileType(["jpeg","jpg","png"])]);
    
    this.formProduct.controls.imagen.updateValueAndValidity();

    if(event.target.files && event.target.files.length && this.formProduct.controls.imagen.valid) {

      const [file] = event.target.files;
      reader.readAsArrayBuffer(file);
    
      reader.onloadend = () => {
        const arrayBuffer: any = reader.result,
        array = new Uint8Array(arrayBuffer);
        const fileByteArray = [];
        for (let i = 0; i < array.length; i++) {
            fileByteArray.push(array[i]);
        }
        this.formProduct.controls.file.patchValue(fileByteArray);
      };

      reader = new FileReader();
      reader.onload = () => {
        this.imageURL = reader.result as string;
      }
      reader.readAsDataURL(file);
    }
  }

  save() {
    this.submit = true;
    if (this.formProduct.valid) {
      if (this.id) {
        this.productService.update(new Producto(this.formProduct.value))
        .subscribe(x => {
          history.back();
          alert(x.message);
        });
      } else {
        this.productService.new(new Producto(this.formProduct.value))
        .subscribe(x => {
          history.back();
          alert(x.message);
        });
      }
    }
  }

}
