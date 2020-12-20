namespace api.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Auth
        {
            public const string Login = Base + "/auth/login";
            public const string Register = Base + "/auth/register";
            public const string Refresh = Base + "/auth/refresh";
            public const string Profile = Base + "/auth/profiles";
        }
        public static class Product
        {
            public const string Create = Base + "/products";
            public const string GetAll = Base + "/products";
            public const string GetById = Base + "/products/{productId}";
            public const string Update = Base + "/products/{productId}";
            public const string Delete = Base + "/products/{productId}";
        }

        public static class Categories
        {
            public const string GetAll = Base + "/categories";
            public const string Create = Base + "/categories";
            public const string Update = Base + "/categories/{categoryId}";
            public const string Delete = Base + "/categories/{categoryId}";
        }

        public static class GoodsReceivingNotes
        {
            public const string CreateGoodsReceivingNotes = Base + "/goodsReceivingNotes";
            public const string DeleteGoodsReceivingNotes = Base + "/goodsReceivingNotes/{goodsReceivingNoteId}";
            public const string GetAll = Base + "/goodsReceivingNotes";
            public const string GetById = Base + "/goodsReceivingNotes/{goodsReceivingNoteId}";
            public const string CreateGoodsReceivingDetails = Base + "/goodsReceivingNotes/{goodsReceivingNoteId}/goodsReceivingDetails";
        }

        public static class Orders
        {
            public const string Create = Base + "/orders";
            public const string GetAll = Base + "/orders";
            public const string GetById = Base + "/orders/{orderId}";
            public const string Update = Base + "/orders/{orderId}";
            public const string Delete = Base + "/orders/{orderId}";
        }

        public static class GoodsDeliveryNotes
        {
            public const string Create = Base + "/goodsDeliveryNotes";
            public const string GetAll = Base + "/goodsDeliveryNotes";
            public const string GetById = Base + "/goodsDeliveryNotes/{goodsDeliveryNoteId}";
            public const string Update = Base + "/goodsDeliveryNotes/{goodsDeliveryNoteId}";
            public const string Delete = Base + "/goodsDeliveryNotes/{goodsDeliveryNoteId}";
            public const string AddProductsToGoodsDeliveryNote = Base + "/goodsDeliveryNotes/{goodsDeliveryNoteId}/goodsDeliveryDetails";
            public const string BulkUpdateProductsInGoodsDeliveryNote = Base + "/goodsDeliveryNotes/{goodsDeliveryNoteId}/goodsDeliveryDetails/bulkUpdate";
            public const string BulkDeleteProductsInGoodsDeliveryNote = Base + "/goodsDeliveryNotes/{goodsDeliveryNoteId}/goodsDeliveryDetails/bulkDelete";
        }

        public static class Users
        {
            public const string Create = Base + "/users";
            public const string Update = Base + "/users/{userId}";
            public const string Delete = Base + "/users/{userId}";
            public const string BanUser = Base + "/users/ban/{userId}";
            public const string GetAll = Base + "/users";
        }

    }
}