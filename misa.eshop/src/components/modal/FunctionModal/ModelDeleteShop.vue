<template>
  <BaseModalForm ref="BaseForm">
    <div class="dialog-form form-confirm-delete">
      <!-- Begin dialog header -->
      <div class="dialog-header">
        <div class="dialog-header-content">
          <div class="dialog-title" id="dialog-title">Xóa dữ liệu</div>
          <div class="dialog-button">
            <button
              class="t-btn btn-close t-icon"
              id="btn-close"
              @click="hide()"
            ></button>
          </div>
        </div>
      </div>
      <!-- End dialog header -->
      <!-- Begin dialog delete -->
      <div class="dialog-confirm-delete">
        <div class="dialog-content">
          <div class="content-confirm">
            <div class="icon-confirm"></div>
            <div class="msg-confirm-delete">
              Bạn có chắc chắn muốn xóa
              <span class="store-name-selected">{{selectedShop.storeName}}</span>
              khỏi danh sách cửa hàng?
            </div>
          </div>
        </div>
        <div class="dialog-footer footer-confirm-delete">
          <div class="dialog-footer-btn">
            <button
              class="t-btn d-btn btn-delete-record"
              id="btn-delete-record"
              tabindex="1"
              @click="deleteRecord(selectedShop.storeId)"
            >
              <div class="t-icon icon-delete"></div>
              <span>Xóa</span>
            </button>
            <button
              class="t-btn d-btn btn-cancel"
              id="btn-cf-cancel"
              tabindex="2"
              @click="hide()"
            >
              <div class="t-icon icon-cancel"></div>
              <span>Hủy bỏ</span>
            </button>
          </div>
        </div>
      </div>
      <!-- End dialog delete -->
    </div>
  </BaseModalForm>
</template>

<script>
import axios from "axios";
import BaseModalForm from "../BaseModalForm";
export default {
  components: {
    BaseModalForm,
  },
  props:{
    selectedShop: Object
  },
  methods: {
    hide() {
      // this.$emit("closeDialog");
      this.$refs.BaseForm.hide();

    },
    show(){
      this.$refs.BaseForm.show();
    },
    deleteRecord(id){
      axios.delete("http://localhost:35480/api/v1/stores/"+id)
        .then((respone) => {
          console.log(respone);
          this.$emit("deleteDone");
        })
        .catch((error) => console.log(error));
    }
  },
};
</script>

<style>
</style>

