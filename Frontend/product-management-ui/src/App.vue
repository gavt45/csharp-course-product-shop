<script setup lang="ts">
import { ref } from 'vue';
import { RouterLink, RouterView } from 'vue-router'
import HelloWorld from './components/HelloWorld.vue'
import { computed } from '@vue/reactivity';

const drawerLeft = ref(false);
</script>

<template>
  <div class="q-pa-md">
    <q-layout view="hHh Lpr lff" container style="height: 100vh" class="shadow-2">
      <q-header elevated>
        <q-toolbar>
          <q-btn flat round dense icon="menu" class="q-mr-sm" @click="drawerLeft = !drawerLeft" />
          <!-- <q-avatar>
            <img src="https://cdn.quasar.dev/logo-v2/svg/logo-mono-white.svg">
          </q-avatar> -->

          <q-toolbar-title>Product management</q-toolbar-title>

          <q-btn flat round dense icon="whatshot" />
        </q-toolbar>
      </q-header>

      <q-drawer
        v-model="drawerLeft"
        :width="200"
        :breakpoint="700"
        elevated
        class="bg-primary text-white"
      >
        <q-scroll-area class="fit">
          <div class="q-pa-sm">
            <!-- <div v-for="n in 50" :key="n">Drawer {{ n }} / 50</div> -->
            <nav>
              <RouterLink to="/">Home</RouterLink>
              <!-- <RouterLink to="/about">About</RouterLink> -->
            </nav>
          </div>
        </q-scroll-area>
      </q-drawer>

      <!-- <q-footer elevated>
        <q-toolbar>
          <q-toolbar-title>Footer</q-toolbar-title>
        </q-toolbar>
      </q-footer> -->

      <q-page-container>
        <RouterView />
      </q-page-container>
    </q-layout>
  </div>
</template>

<style scoped>
.q-pa-md {
  /* padding: 0%; */
  padding-block: 0%;
  padding-left: 0%;
  padding-right: 0%;
  padding-bottom: 0%;
}
</style>
