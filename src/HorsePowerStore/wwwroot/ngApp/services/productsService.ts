﻿namespace HorsePowerStore.Services {
    export class ProductsService {
        private productsResource;
        public ratings;
        public productId;

        constructor(
            $resource: ng.resource.IResourceService,
            $stateParams: ng.ui.IStateParamsService) {

            this.productId = $stateParams['id'];
            console.log(this.productId);

            this.productsResource = $resource("/api/products", {}, {
                getProductWithRatings: {
                    method: 'GET',
                    url: '/api/products/:id/ratings/:page'
                },
                listProducts: {
                    method: 'GET',
                    url: '/api/products/:page',
                    isArray: true
                },
                addRating: {
                    method: 'POST',
                    url: '/api/products/addRating',
                },
                removeRating: {
                    method: 'POST',
                    url: '/api/products/removeRating',
                }
            });
        }

        public getProduct(productId: number) {
            return this.productsResource.getProductWithRatings({ id: productId, page:0 });
        }

        public addRating(rating) {
            return this.productsResource.addRating(rating);
        }

        public removeRating(ratingId: number) {
            return this.productsResource.removeRating({ id: ratingId });
        }

        public listProducts(page: number) {
            return this.productsResource.listProducts({ page: page });
        }
    }
    angular.module('HorsePowerStore').service('productsService', ProductsService);
}