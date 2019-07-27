# Security-Door-Modeling
[![Build Status](https://dev.azure.com/SecureDevTeam/SecureDoors/_apis/build/status/securedevteam.Security-Door-Modeling?branchName=master)](https://dev.azure.com/SecureDevTeam/SecureDoors/_build/latest?definitionId=2&branchName=master)

Разработанный комплекс приложений необходим для моделирования данных для Console App приложения SecurityDoors.DoorController. Основной идей является генерация и последующая отправка полученных данных из файла или по средствам WebAPI веб-приложения SecurityDoors.App. Основных интерфейсов в разработанном комплексе 3: WPF, WinForms и ConsoleApp. 

Что было реализовано:
- Windows Forms (WinFoms) приложение.
- Windows Presentation Foundation (WPF) приложение.
- Console App on Framework 4.7 приложение.
- Настройка соединения с сервером и веб-приложением.
- Возможность тестового соединения и проверка данных.
- Сохранение и возврат к стандартным данных соединения.
- Загрузка данных из файла.
- Возможность получения данных от сервера через WebAPI.
- Обновление полученных данных от сервера.
- Отображение полученных данных от сервера.
- Моделирование и отправка выбранных данных на сервер.
- Многофункциональный лог для всех типов приложения.

Используемый стек технологий:
- Windows Forms (WinFoms);
- Windows Presentation Foundation (WPF);
- Console App on Framework 4.7;
- N-Layer архитектура;
- Entity Framework Core;
- LINQ (Language-Integrated Query);
- Manual и xUnit тестирование;
- Использования данных от WebAPI;
- Система контроля версий: Git;
- Система менеджмента заданий: Trello;
- Непрерывная интеграция: Azure Pipelines;
