import { createRouter, createWebHashHistory, RouteRecordRaw } from 'vue-router'

const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    component: () => import('@/views/Form/Form.vue')
  },
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
