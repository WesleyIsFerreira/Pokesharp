import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Pokemons from '../views/Pokemons.vue'

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/home',
    name: 'Home',
    component: Home

  },
  {
    path: '/pokemons',
    name: 'Pokemons',
    component: Pokemons

  },
  {
    path: '/about',
    name: 'About',
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import(/* webpackChunkName: "about" */ '../views/About.vue')
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})

router.beforeEach((to, from, next) => {
  const publicPages = ['/']
  const authRequired = !publicPages.includes(to.path)

  let loggedIn = false

  if (localStorage.getItem('token') && localStorage.getItem('token').includes('Bearer'))
    loggedIn = true

  if (authRequired && !loggedIn) {
    next('/')
  } else {
    next()
  }
})

export default router
