# OnlineEduPlatform
Проста онлайн платформа за обучение и етап Е1 от моя окончателен курсов проект по софтуерни технологии. 

## Features
 - Преглед на списък с всички курсове.
 - Създаване на нов курс с избор на учител, който ще го ръководи.
 - Преглед на детайли на курс.
 - Записване на студент в курс.
 - Изтриване на курс.

## Requirements
За да стартирате проекта, вашата машина трябва да има инсталирана:
  *   [Docker Desktop](https://www.docker.com/products/docker-desktop/)

## Launch
1. **Клонирайте хранилището:**
   ```bash
   git clone https://github.com/199knz-bit/OnlineEduPlatform.git
   cd OnlineEduPlatform
   
2. **Изградете Docker контейнера:**
   ```bash
   docker build -t onlineeduplatform .

3. **Стартирайте контейнера:**
   ```bash
   docker run -d -p 8080:8080 -v learning_data:/app/data --name onlineedu onlineeduplatform

4. **Отворете програмата в браузър:**
   http://localhost:8080/Courses

## Stopping and deleting
1. **За спиране на приложението:**
   ```bash
   docker stop onlineedu

2. **За да рестартирате приложението:**
   ```bash
   docker start onlineedu

3. **За да изтриете контейнера и базата данни:**
   ```bash
   docker rm -f onlineedu
   docker volume rm learning_data
