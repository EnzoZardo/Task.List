import { createRouter, createWebHistory } from 'vue-router'

// #region Views
const HomeView = () => import('@/views/HomeView.vue')
const FiltersView = () => import('@/views/Filters/FiltersView.vue')
// #endregion

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [ 
    { 
      path: '/',
      children: [
            {
              path: '',
              name: 'home',
              component: HomeView,
            },
            {
              path:'filters',
              name: 'filters',
              component: FiltersView
            }
        ]
      },
    ]
})

export default router
