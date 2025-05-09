﻿# MVP Calculator (.NET 9, WinForms)

Простой калькулятор с архитектурой MVP, реализованный на WinForms и .NET 9. 

## Возможности
- Поддержка базовых операций: `+`, `-`, `*`, `/`, скобки, десятичные числа
- Архитектура **MVP** (Model-View-Presenter)
- Пользовательский парсер выражений (без использования DataTable)

## Применённые паттерны
- **MVP** — основная архитектура приложения (разделение View, Presenter, Model)
- **Strategy** — каждая арифметическая операция реализована как отдельная стратегия
- **Factory Method** — для выбора стратегии выполнения операции

## Структура
- `Model/Parsing/ExpressionParser.cs` — парсер и вычислитель выражений
- `Model/Operation/` — паттерны `Strategy` и `Factory`
- `View/` — интерфейс пользователя на WinForms
- `Presenter/` — логика связки Model и View

## Запуск
1. Откройте решение в Visual Studio 2022+
2. Запустите проект `CalculatorApp`