import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    component: () => import('@/views/Form/Form.vue')
  },
  {
    path: '/list',
    component: () => import('@/views/List/List.vue')
  },
  {
    path: '/loginPage',
    component: () => import('@/views/LoginPage/LoginPage.vue')
  },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
