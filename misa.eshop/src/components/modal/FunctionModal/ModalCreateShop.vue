<template>
  <BaseModalForm ref="BaseForm_ref">
    <div class="dialog-form form-add-edit">
      <div class="dialog-header">
        <div class="dialog-header-content">
          <div class="dialog-title" id="dialog-title">{{ titleDialog }}</div>
          <div class="dialog-button">
            <button
              class="t-btn btn-close t-icon"
              id="btn-close"
              @click="hide()"
            ></button>
          </div>
        </div>
      </div>
      <div class="dialog-add-edit">
        <div class="dialog-content-top">
          <div class="form-group t-row">
            <p class="label-text text-one-line">
              Mã cửa hàng<span class="text-color-red">&nbsp;*</span>
            </p>
            <input
              class="form-control t-input"
              id="storeCodeFocus"
              required
              tabindex="1"
              ref="storeCode"
              :class="{ 'boder-warning': !validate.storeCode }"
              v-model="store.storeCode"
              @blur="validateStoreCode()"
              @input="validateStoreCode()"
            />
            <span v-show="!validate.storeCode" class="warning">
              <span class="tooltiptext">{{ warningMsg1 }}</span>
            </span>
          </div>
          <div class="form-group t-row">
            <p class="label-text text-one-line">
              Tên cửa hàng<span class="text-color-red">&nbsp;*</span>
            </p>
            <input
              class="form-control t-input"
              required
              tabindex="2"
              :class="{ 'boder-warning': !validate.storeName }"
              v-model="store.storeName"
              @blur="validateStoreName()"
              @input="validateStoreName()"
            />
            <span v-show="!validate.storeName" class="warning">
              <span class="tooltiptext">{{ warningMsg2 }}</span>
            </span>
          </div>
          <div class="form-group t-row">
            <p class="label-text text-one-line">
              Địa chỉ<span class="text-color-red">&nbsp;*</span>
            </p>
            <textarea
              class="form-control t-input"
              id="txt-address"
              required
              rows="4"
              tabindex="3"
              :class="{ 'boder-warning': !validate.address }"
              v-model="store.address"
              @blur="validateAddress()"
              @input="validateAddress()"
            >
            </textarea>
            <span v-show="!validate.address" class="warning">
              <span class="tooltiptext">{{ warningMsg3 }}</span>
            </span>
          </div>
        </div>
        <div class="dialog-content-bottom">
          <div class="t-row">
            <div class="form-group col-50">
              <p class="label-text text-one-line">Số điện thoại</p>
              <input
                class="form-control t-input"
                tabindex="4"
                :class="{ 'boder-warning': !validate.phoneNumber }"
                v-model="store.phoneNumber"
                @blur="validatePhoneNumber()"
                @input="validatePhoneNumber()"
              />
              <span v-show="!validate.phoneNumber" class="warning">
                <span class="tooltiptext tooltipPhoneNumber">{{
                  warningMsg4
                }}</span>
              </span>
            </div>
            <div class="form-group col-50">
              <p class="label-text text-one-line">Mã số thuế</p>
              <input
                class="form-control t-input"
                tabindex="5"
                v-model="store.storeTaxCode"
              />
            </div>
          </div>
          <div class="t-row">
            <div class="form-group col-50">
              <p class="label-text text-one-line">Quốc gia</p>
              <select
                class="form-control t-input"
                tabindex="6"
                v-model="store.countryId"
              >
                <!-- v-model="selectedCountry" -->
                <option value="null" selected disabled>Chọn quốc gia</option>
                <option
                  v-for="item in country"
                  :key="item.value"
                  v-bind:value="item.value"
                >
                  {{ item.text }}
                </option>
              </select>
            </div>
            <div class="form-group col-50"></div>
          </div>
          <div class="t-row">
            <div class="form-group col-50">
              <p class="label-text text-one-line">Tỉnh/Thành phố</p>
              <select
                class="form-control t-input"
                tabindex="7"
                v-model="store.provinceId"
                :disabled="!store.countryId"
              >
                <!-- v-model="selectedProvince" -->
                <option value="null" selected disabled>
                  Chọn tỉnh/thành phố
                </option>
                <option
                  v-for="item in province"
                  :key="item.value"
                  :value="item.value"
                >
                  {{ item.text }}
                </option>
              </select>
            </div>
            <div class="form-group col-50">
              <p class="label-text text-one-line">Quận/Huyện</p>
              <select
                class="form-control t-input"
                tabindex="8"
                v-model="store.districtId"
                :disabled="!store.provinceId"
              >
                <!-- v-model="selectedDistrict" -->
                <option value="null" selected disabled>Chọn quận/huyện</option>
                <option
                  v-for="item in district"
                  :key="item.value"
                  v-bind:value="item.value"
                >
                  {{ item.text }}
                </option>
              </select>
            </div>
          </div>
          <div class="t-row">
            <div class="form-group col-50">
              <p class="label-text text-one-line">Phường/Xã</p>
              <select
                class="form-control t-input"
                tabindex="9"
                v-model="store.wardId"
                :disabled="!store.districtId"
              >
                <option value="null" selected disabled>Chọn phường/xã</option>
                <option
                  v-for="item in ward"
                  :key="item.value"
                  v-bind:value="item.value"
                >
                  {{ item.text }}
                </option>
              </select>
            </div>
            <div class="form-group col-50">
              <p class="label-text text-one-line">Đường phố</p>
              <input
                class="form-control t-input"
                tabindex="10"
                v-model="store.street"
              />
            </div>
          </div>
        </div>
        <!-- <div class="dialog-content">
          
        </div> -->
      </div>
      <div class="dialog-footer footer-add-edit">
        <div class="dialog-footer-left">
          <button
            class="t-btn dialog-btn-help"
            id="btn-help-dialog"
            tabindex="14"
          >
            <i class="t-icon t-icon-help"></i>
            <span class="dialog-help-text">Trợ giúp</span>
          </button>
        </div>
        <div class="dialog-footer-right">
          <button
            class="t-btn d-btn btn-save"
            id="btn-save"
            tabindex="11"
            @click="save('save')"
          >
            <div class="t-icon icon-save"></div>
            <span>Lưu</span>
          </button>
          <button
            class="t-btn d-btn btn-save-add"
            id="btn-save-add"
            tabindex="12"
            @click="save('new')"
          >
            <div class="t-icon icon-save-add"></div>
            <span>Lưu và thêm mới</span>
          </button>
          <button
            class="t-btn d-btn btn-cancel"
            id="cancel"
            tabindex="13"
            @click="hide()"
          >
            <div class="t-icon icon-cancel"></div>
            <span>Hủy bỏ</span>
          </button>
        </div>
      </div>
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
  props: {
    msg: String,
    selectedShopId: String,
  },
  data() {
    return {
      titleDialog: "Thêm mới cửa hàng",
      store: {
        // storeId: null,
        storeCode: "",
        storeName: "",
        address: "",
        phoneNumber: "",
        storeTaxCode: "",
        countryId: null,
        provinceId: null,
        districtId: null,
        wardId: null,
        status: 0,
        street: "",
        createDate: new Date(),
        createUserId: "149fb958744f70c67709bf1378b8dc91",
      },

      country: [],
      province: [],
      district: [],
      ward: [],

      warningMsg1: "",
      warningMsg2: "",
      warningMsg3: "",
      warningMsg4: "",
      inputBlur: true,

      checkDuplicate: true,
      validate: {
        storeCode: true,
        storeName: true,
        address: true,
        phoneNumber: true,
      },

      alertMessage: "",
    };
  },
  methods: {
    /**
     * Ẩn dialog thêm sửa, sự kiện khi click vào nút Hủy hoặc button x
     * CreatedBy: nctu 16.04.2021
     */
    hide() {
      this.$refs.BaseForm_ref.hide();
      this.resetForm();
    },

    /**
     * Hiện dialog thêm sửa
     * CreatedBy: nctu 16.04.2021
     */
    show() {
      this.getCountryData();
      this.$refs.BaseForm_ref.show();
    },

    /**
     * Lấy thông tin 1 bản ghi theo Id của bản ghi đó khi chọn thao tác sửa
     * CreatedBy: nctu 17.04.2021
     */
    getStoreById() {
      if (this.selectedShopId) {
        axios
          .get("http://localhost:35480/api/v1/stores/" + this.selectedShopId)
          .then((respone) => {
            console.log(respone);
            this.store = respone.data.data;
          })
          .catch((error) => console.log(error.data.devMsg));
      }
    },

    /**
     * Sự kiện khi click vào nút Lưu
     * CreatedBy: nctu 15.04.2021
     */
    save(text) {
      // kiểm tra xem thao tác đang thực hiện với dialog là thêm - post hay sửa - put
      switch (this.msg) {
        case "post": {
          if (this.validateForm()) {
            this.$delete(this.store, "storeId");
            axios
              .post("http://localhost:35480/api/v1/stores/", this.store)
              .then((respone) => {
                console.log(`add success ${respone.data}`);
                if (text == "save") {
                  this.alertMessage = "Thêm thành công";
                  this.$emit("showAlertDialog", this.alertMessage);
                } else {
                  this.alertMessage = "Thêm thành công";
                  this.$emit("showAlertDialog", this.alertMessage);
                  this.show();
                }
              })
              .catch((error) => {
                console.log(error.data);
                this.alertMessage = "Có lỗi xảy ra, vui lòng liên hệ MISA";
                this.$emit("showAlertDialog", this.alertMessage);
              });
          } else {
            this.alertMessage =
              "Vui lòng nhập đủ thông tin yêu cầu trước khi lưu";
            this.$emit("showAlertDialog", this.alertMessage);
          }
          break;
        }
        case "put": {
          if (this.validateForm()) {
            axios
              .put(
                `http://localhost:35480/api/v1/stores/${this.selectedShopId}`,
                this.store
              )
              .then((respone) => {
                console.log(`success ${respone.data}`);
                console.log("Sửa");
                if (text == "save") {
                  this.alertMessage = "Cập nhật thành công";
                  this.$emit("showAlertDialog", this.alertMessage);
                } else {
                  // this.resetForm();
                  this.alertMessage = "Cập nhật thành công";
                  this.$emit("showAlertDialog", this.alertMessage);
                  this.show();
                }
              })
              .catch((error) => {
                console.log(error.data);
                this.alertMessage = "Có lỗi xảy ra, vui lòng liên hệ MISA";
                this.$emit("showAlertDialog", this.alertMessage);
              });
          } else {
            this.alertMessage =
              "Vui lòng nhập đủ thông tin yêu cầu trước khi lưu";
            this.$emit("showAlertDialog", this.alertMessage);
          }
          break;
        }
      }
    },

    /**
     * Lấy danh sách quốc gia từ api
     * createdBy: nctu 15.04.2021
     */
    getCountryData() {
      axios
        .get("http://localhost:35480/api/v1/Countrys")
        .then((respone) => {
          var option = [];
          respone.data.data.forEach((element) => {
            option.push({
              text: element.countryName,
              value: element.countryId,
            });
          });
          this.country = option;
        })
        .catch((error) => console.log(error));
    },

    /**
     * lấy danh sách tỉnh/thành phố theo quốc gia
     * createdBy: nctu 15.04.2021
     */
    getProvinceData() {
      if (this.store.countryId) {
        axios
          .get(
            `http://localhost:35480/api/v1/Provinces/WithCountry/${this.store.countryId}`
          )
          .then((respone) => {
            var option = [];
            respone.data.data.forEach((element) => {
              option.push({
                text: element.provinceName,
                value: element.provinceId,
              });
            });
            this.province = option;
          })
          .catch((error) => console.log(error));
      }
    },

    /**
     * lấy danh sách quận/huyện theo tỉnh/thành phố
     * createdBy: nctu 15.04.2021
     */
    getDistrictData() {
      if (this.store.provinceId) {
        axios
          .get(
            `http://localhost:35480/api/v1/Districts/WithProvince/${this.store.provinceId}`
          )
          .then((respone) => {
            var option = [];
            respone.data.data.forEach((element) => {
              option.push({
                text: element.districtName,
                value: element.districtId,
              });
            });
            this.district = option;
          })
          .catch((error) => console.log(error));
      }
    },
    /**
     * lấy danh sách phường/xã theo quận/huyện
     * createdBy: nctu 15.04.2021
     */
    getWardData() {
      if (this.store.districtId) {
        axios
          .get(
            `http://localhost:35480/api/v1/Wards/WithDistrict/${this.store.districtId}`
          )
          .then((respone) => {
            var option = [];
            respone.data.data.forEach((element) => {
              option.push({
                text: element.wardName,
                value: element.wardId,
              });
            });
            this.ward = option;
          })
          .catch((error) => console.log(error));
      }
    },

    // reset dữ liệu trong form
    resetForm: function () {
      this.store.storeId = null;
      this.store.storeCode = "";
      this.store.storeName = "";
      this.store.address = "";
      this.store.phoneNumber = "";
      this.store.storeTaxCode = "";
      this.store.wardId = null;
      this.store.countryId = null;
      this.store.provinceId = null;
      this.store.districtId = null;
      this.store.street = "";

      this.validate.storeCode = true;
      this.validate.storeName = true;
      this.validate.address = true;
      this.validate.phoneNumber = true;
    },

    /**
     * Validate dữ liệu khi thêm và sửa
     * CreatedBy: nctu 15.04.2021
     * ModifiedBy: nctu 16.04.2021
     */
    validateForm() {
      if (
        !this.validateStoreCode() ||
        !this.validateStoreName() ||
        !this.validateAddress() ||
        !this.validatePhoneNumber()
      ) {
        return false;
      }
      return true;
    },
    /**
        Kiểm tra mã cửa hàng: trống hoặc trùng
        CreatedBy: nctu 16.04.2021
     */
    validateStoreCode() {
      var valid = true;
      if (!this.store.storeCode) {
        this.validate.storeCode = false;
        this.warningMsg1 = "Trường này không được để trống";
        valid = false;
      } else {
        this.validate.storeCode = true;
        valid = true;
        this.checkDuplicateCode(this.store.storeCode);
      }
      return valid;
    },
    /**
        Kiểm tra tên cửa hàng xem có trống không
        CreatedBy: nctu 16.04.2021
     */
    validateStoreName() {
      let valid = true;
      if (!this.store.storeName) {
        this.validate.storeName = false;
        this.warningMsg2 = "Trường này không được để trống";
        valid = false;
      } else {
        this.validate.storeName = true;
        valid = true;
      }
      return valid;
    },
    /**
        Kiểm tra địa chỉ
        CreatedBy: nctu 16.04.2021
     */
    validateAddress() {
      let valid = true;
      if (!this.store.address) {
        this.validate.address = false;
        this.warningMsg3 = "Trường này không được để trống";
        valid = false;
      } else {
        this.validate.address = true;
        valid = true;
      }
      return valid;
    },
    /**
     * Kiểm tra số điện thoại
     * createdBy: nctu 19.04.2021
     */
    validatePhoneNumber() {
      var phone = /^\d{10}$/;
      let valid = true;
      if (
        !this.store.phoneNumber.match(phone) &&
        this.store.phoneNumber != ""
      ) {
        this.validate.phoneNumber = false;
        this.warningMsg4 = "Số điện thoại không đúng định dạng";
        valid = false;
      } else {
        this.validate.phoneNumber = true;
        valid = true;
      }
      return valid;
    },

    /**
     * Kiểm tra mã cửa hàng xem có bị trùng hay không
     * createdBy: ntu 15.04.2021
     */
    checkDuplicateCode(storeCode) {
      axios
        .get("http://localhost:35480/api/v1/stores/getbycode", {
          params: {
            storeCode: storeCode,
          },
        })
        .then((respone) => {
          let valid = true;
          if (respone.data.errorCode == 400) {
            if (this.msg == "put") {
              if (respone.data.data.storeId != this.store.storeId) {
                this.validate.storeCode = false;
                this.warningMsg1 = "Mã cửa hàng đã tồn tại - sửa ";
                valid = false;
              } else {
                this.validate.storeCode = true;
                valid = true;
              }
            } else {
              this.validate.storeCode = false;
              this.warningMsg1 = "Mã cửa hàng đã tồn tại - thêm ";
              valid = false;
            }
          } else {
            this.validate.storeCode = true;
            valid = true;
          }
          return valid;
        })
        .catch((error) => {
          console.log(error);
        });
    },
  },

  watch: {
    // theo dõi id shop được chọn
    selectedShopId() {
      if (this.msg == "put") {
        this.getStoreById();
        this.titleDialog = "Sửa thông tin cửa hàng";
      } else if (this.msg == "post") {
        this.resetForm();
        this.titleDialog = "Thêm mới cửa hàng";
      }
    },
    msg() {
      if (this.msg == "put") {
        this.getStoreById();
        this.titleDialog = "Sửa thông tin cửa hàng";
      } else if (this.msg == "post") {
        this.resetForm();
        this.titleDialog = "Thêm mới cửa hàng";
      }
    },
    "store.countryId"() {
      this.getProvinceData();
      this.store.provinceId = null;
      this.store.districtId = null;
      this.store.wardId = null;
    },
    "store.provinceId"() {
      this.getDistrictData();
      this.store.districtId = null;
      this.store.wardId = null;
    },
    "store.districtId"() {
      this.getWardData();
      this.store.wardId = null;
    },
  },
};
</script>

<style>
/* @import "../../../styles/dialog.css"; */
.tooltiptext {
  visibility: hidden;
  width: 150px;
  line-height: 20px;
  background-color: #df4646;
  border-radius: 3px;
  color: #fff;
  text-align: center;
  padding: 4px 3px;
  position: fixed;
  left: calc(50% + 300px);
  z-index: 1;
}

.tooltiptext::after {
  content: " ";
  position: absolute;
  width: 0;
  height: 0;
  left: -14px;
  right: auto;
  top: 4px;
  bottom: auto;
  border: 7px solid;
  border-color: transparent #df4646 transparent transparent;
}

.tooltipPhoneNumber {
  left: calc(50% + 5px);
}

.warning {
  cursor: pointer;
}

.warning:hover .tooltiptext {
  visibility: visible;
}
</style>