# Game Marketplace

This is a full-stack web application that displays a game marketplace with game cards, search, and discounts.

The frontend is built with **React (Vite)** and shows a marketplace-style UI where users can browse games, search by name, and see discounted listings.  
The backend is an **ASP.NET Core Web API** that exposes a public `/list` endpoint with search support and serves data from a PostgreSQL database hosted on Supabase.

The website is accessible via: https://eneba-assignment.vercel.app/


---

## Tech Stack

### Frontend
- React
- Vite
- TypeScript / JavaScript
- Deployed on **Vercel**

### Backend
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (Supabase)
- Deployed on **Railway**

### Database
- PostgreSQL (Supabase)
- EF Core migrations and seeding

---

## Features

- Game marketplace UI with cards
- Search with query support (`/list?search=`)
- Discounts on selected game listings
- Backend REST API for fetching game data

---

## Api overview

GET /list – returns all game listings
GET /list?search=term – returns filtered results based on search input

---
## Deployment

Backend: Railway
Database: Supabase (PostgreSQL)
Frontend: Vercel
