# Zara Tech Code
Result value: **32994.432**
Para resolver el reto ZaraTechCode primeramente creé la clase DailyStock, la cual se encarga de modelar las propiedades
DateTime(fecha), OpenDay(apertura) y CloseDay(cierre) de cada dia que la empresa Inditex cotiza en bolsa. Luego añadí 
otra clase (ExcelSource) que es la encargada de extraer los datos de el archivo excel y devolver una lista de tipo DailyStock
la cual utilizo en la clase(InvestmentSimulator) donde hago el cálculo que devuelve el capital final obtindo y una lista de 
la ganancia que va obteniendo al final de cada mes desde el comienzo de la inversión hasta el dia de la venta de sus acciones.
Para tramitar los datos de la lista que luego voy a exportar a un archivo excel, creé la clase Income donde modelo las 
propiedades y la clase ExcelGenerator de tipo Income es la que se encarga de exportar la lista al excel. Adicionalmente 
está el Unit Test con 3 métodos de prueba para el método GetFinalCapital de la clase InvestmentSimulator. 