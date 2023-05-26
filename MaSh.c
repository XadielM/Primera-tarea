#include <stdio.h>
#include <stdlib.h>

#define size 100

int main(){
    int a1, a2, lista[size], num, aux;

    //Input de la cantidad de datos que el usuario quiere poner

    printf("\nCuantos datos vas a ingresar? ");
    scanf("%d", &num);



    for(a1 = 0; a1<num; a1 = a1+1){
        printf("\nDame el dato %d: ", a1+1);
        scanf("%d", &lista[a1]);
    }

    //Ordenando los datos

    for(a1 = 0; a1<num; a1 = a1+1){
        for(a2 =0; a2<num; a2= a2+1){
            if(lista[a1] < lista[a2]){
                aux = lista[a1];
                lista[a1] = lista[a2];
                lista[a2] = aux;
            }
        }
    }


    //Mostrando los numeros ya ordenados

    printf("\n\nTus numeros ordenados de menor a mayor: ");
    for(a1 = 0; a1<num; a1 = a1+1){
        printf("%d,", lista[a1]);
    }
    return 0;
}
