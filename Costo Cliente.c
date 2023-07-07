#include <stdio.h>
#include <stdlib.h>

char client_name[10]; // Nombre del cliente
int num_clients = 1; // Para indicar la cantidad de clientes
int num_clientsMAX; // Input de la cantidad de cliente que vamos a ingresar
int consumo_prom;
int galones_a_litros; 
int pcl = 85; // Precio combustible en litros
int gomas; // Cantidad de gomas compradas
int gasto_en_gomas;
int precio_de_gomas = 7300;
float total;
float gastoVTotal;
float seguro;
float GaL = 3.78541; // Convettir Galones a L
float precio_combustible;
float KM_recorrer; // Kilometros recorridos
float cantidad_Combustible; // 221.60 por Galon
float Gastos_varios; // Cambio de aceite, lavado de carro, seguro, etc.

int main()
{
    // Pidiendo la informacion de los clientes

    printf("\nInserte el numero del clientes: ");
    scanf("%d", &num_clientsMAX);

    while(num_clients <= num_clientsMAX)
    // Loop para que se repita segun la cantidad de clientes que indiquemos

        {
            printf("\nNombre del cliente %d: ", num_clients);
            scanf("%s", &client_name);
            printf("\n\n\t\t\tBienvenido/a %s \n", client_name);
            printf("\nCuantos kilometros va a recorrer?: ");
            scanf("%f", &KM_recorrer);
            printf("Ingrese el consumo promedio (8-16L/100KM): ");
            scanf("%d", &consumo_prom);

            if (consumo_prom >= 6 && consumo_prom <= 16)
            {
                printf("Ingreses la cantidad de galones de combustible que quiere: ");
                scanf("%f", &cantidad_Combustible);
                printf("Ingrese la cantidad de gastos varios (cambio de aceite, lavado de carro, cambio de filtros): ");
                scanf("%f", &Gastos_varios);
                printf("Cuanto paga de seguro mensual?: ");
                scanf("%f", &seguro);
                printf("Cuantas gomas compraste?: ");
                scanf("%d", &gomas);

                galones_a_litros = cantidad_Combustible * GaL; // Transformando de galones a litros
                precio_combustible = galones_a_litros * pcl; // Operacion para calcular el precio de combustible 
                gasto_en_gomas = gomas * precio_de_gomas; // Operacion para calcular el costo total de las gomas
                gastoVTotal = Gastos_varios + seguro + gasto_en_gomas;
                total = precio_combustible + gastoVTotal + gasto_en_gomas; 
                printf("\n\n----------------------------------------------------------------------------------------------------------------------"); // 5 less
                printf("\n| No. | Nombre del cliente |  Consumo | Distancia  | Combustible | Costo combustible | Gastos varios  |     Total    |");
                printf("\n------------------------------------------------------------------------------------------------------------------------");
                printf("\n|  %d  |        %s      | %d/100KM |   %.0fKM    | %d Litros   |    $RD %.2f    |  $RD %.2f  | $RD %.2f |", num_clients, client_name, consumo_prom, KM_recorrer, galones_a_litros, precio_combustible, gastoVTotal, total);
                printf("\n------------------------------------------------------------------------------------------------------------------------");

                num_clients++;
            }else
            {
                printf("\n\nEl consumo promedio introducito no es valido, por favor intentelo nuevamente\n");
            
            }
            

        }
        
        
   

    

}