import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    component: () => import('@/views/LoginPage/LoginPage.vue')
  },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
