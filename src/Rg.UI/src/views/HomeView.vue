<template>
  <ChatsControl/>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";
import ChatListControl from "@/components/ChatListsControl.vue";
@Component({
  components: {ChatsControl: ChatListControl}
})
export default class HomeView extends Vue{

};
</script>
