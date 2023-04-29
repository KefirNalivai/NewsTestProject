Работает на SQLServer2019. Для создания базы:

   Создаем базу с названием NewsTestProject ![image](https://user-images.githubusercontent.com/98163662/235315967-5dd091ff-614f-4075-ada0-efc0294a37d0.png)


    И в самой визуалке, в консоли разработчика PowerShell (либо отдельно можно зайти в него) прописываем dotnet ef database update
    
    
    P.S. Если не заработает установка миграции, пишем перед вторым пунктом  dotnet tool install --global dotnet-ef --version 6.0.13
