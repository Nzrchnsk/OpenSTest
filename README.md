# Open-s test

Система с использованием ASP .NET Core 3.1 и Entity Framework, позволяющая принимает заказы и сохраняет их в базу данных для дальнейшей обработки.
Сервис обратаывающий заказы, получает из базы данных новые/необработанные заказы и обрабатывает их. Запускаться с заданной периодичностью в 5 секунд.
В зависимости от типа заказа вызывается специфический код для каждой системы: talabat, zomato, uber. В будущем типов систем может быть больше 3 поэтому решение работет не через if else или swich case, чтобы не нужно было менять код в этом сервисе, при добавлении нового обработчика для новой системы.

# Структура проекта
Система разделен на модули (Onion Architecture).

## Core
Ядро проекта включающее в себя основную логику.

## Infrastructure
Определяет объекты данных, доступ к базе данных. Содержит реализацию интерфейсов, определенных на уровне ядра.

## WebApi
Апи реализующее прием данных от пользователя.

## OrderProcessingService
Сервис для обработки заказов, в фоновом режиме с интервалом времени в 5 секунд.

# Инструкция по запуску

1. Создать базу данных postgres
2. Поменять заглушки в файлах WebApi/appsettings.json и OrderProcessingService/appsettings.json
3. Применить миграции - dotnet ef database update -c ordercontext -p ../Infrastructure/Infrastructure.csproj -s WebApi.csproj
4. Создать папку Logs в корне решения.
5. Имеется 2 точки входа WebApi и OrderProcessingService.

