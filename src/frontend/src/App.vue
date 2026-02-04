<template>
  <v-app>
    <v-main class="bg-primary">
      <router-view v-slot="{ Component }">
        <keep-alive>
          <component :is="Component" />
        </keep-alive>
      </router-view>
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { RouterView } from "vue-router";
</script>
