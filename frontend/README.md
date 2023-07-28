# Ecommerce website - Shop Hive

An ecommerce website as final assignment for frontend section. On the web, customers can explore products, filter them in categories, leave reviews for products, add products to cart. They can also create a personal account and edit their profile. As an admin, client can add, edit, and delete products or categories.

## Link to the demo

[https://integrify-frontend-project-ecommerce.vercel.app](https://integrify-frontend-project-ecommerce.vercel.app)

## Table of content

- [Technologies](#technologies)
- [Project structure](#project-structure)
- [Getting started](#getting-started)

<a name="technologies"></a>

## Technologies

- TypeScript
- React.js
- Redux Toolkits
- SASS

<a name="project-structure"></a>

## Project structure

```
│   .gitignore
│   package-lock.json
│   package.json
│   README.md
│   tsconfig.json
│
├───public
│       favicon.ico
│       index.html
│       robots.txt
│
└───src
    │   .prettierignore
    │   App.tsx
    │   index.scss
    │   index.tsx
    │   prettierrc.json
    │   react-app-env.d.ts
    │   reportWebVitals.ts
    │   setupTests.ts
    │
    ├───assets
    │   ├───images
    │   │   │   hero-banner.jpg
    │   │   │   logo.png
    │   │   │
    │   │   └───payment
    │   │           nordea.png
    │   │           op.png
    │   │           paypal.png
    │   │
    │   └───styles
    │       │   styles.scss
    │       │
    │       ├───components
    │       │       _buttons.scss
    │       │       _categories.scss
    │       │       _error.scss
    │       │       _footer.scss
    │       │       _form.scss
    │       │       _header.scss
    │       │       _loader.scss
    │       │       _pagination.scss
    │       │       _productCard.scss
    │       │       _quantityButton.scss
    │       │       _searchBar.scss
    │       │       _sideCart.scss
    │       │       _singleReview.scss
    │       │       _table.scss
    │       │
    │       ├───mixins
    │       │       _buttons.scss
    │       │
    │       ├───pages
    │       │       _cart.scss
    │       │       _checkout.scss
    │       │       _dashboard.scss
    │       │       _home.scss
    │       │       _login.scss
    │       │       _productDetail.scss
    │       │       _products.scss
    │       │       _registration.scss
    │       │       _userProfile.scss
    │       │
    │       └───variables
    │               _animation.scss
    │               _border.scss
    │               _colors.scss
    │               _font.scss
    │
    ├───components
    │   │   Category.tsx
    │   │   Footer.tsx
    │   │   Header.tsx
    │   │   Helmet.tsx
    │   │   Layout.tsx
    │   │   Pagination.tsx
    │   │   SearchBar.tsx
    │   │   SingleReview.tsx
    │   │
    │   ├───Cart
    │   │       Cart.tsx
    │   │       QuantityButton.tsx
    │   │       SideCartItem.tsx
    │   │
    │   ├───Form
    │   │       AddressForm.tsx
    │   │       CreateCategory.tsx
    │   │       CreateProductForm.tsx
    │   │       EditCategoryForm.tsx
    │   │       EditProductForm.tsx
    │   │       EditUserForm.tsx
    │   │       LoginForm.tsx
    │   │       RegisterForm.tsx
    │   │       ReviewForm.tsx
    │   │
    │   └───Product
    │           ProductCard.tsx
    │           ProductDescription.tsx
    │           ProductList.tsx
    │           ProductMainInfo.tsx
    │
    ├───hooks
    │       useAppDispatch.ts
    │       useAppSelector.ts
    │
    ├───pages
    │   │   Cart.tsx
    │   │   Checkout.tsx
    │   │   Error.tsx
    │   │   Home.tsx
    │   │   Loading.tsx
    │   │   Login.tsx
    │   │   ProductDetail.tsx
    │   │   Products.tsx
    │   │   Registration.tsx
    │   │   UserProfile.tsx
    │   │
    │   └───Admin
    │           CategoryManagement.tsx
    │           Dashboard.tsx
    │
    ├───redux
    │   │   store.ts
    │   │
    │   └───reducers
    │           cartReducer.ts
    │           categoriesReducer.ts
    │           productsReducer.ts
    │           reviewReducer.ts
    │           usersReducer.ts
    │
    ├───routes
    │       Routers.tsx
    │
    ├───tests
    │   ├───data
    │   │       categories.ts
    │   │       products.ts
    │   │       review.ts
    │   │       users.ts
    │   │
    │   ├───reducers
    │   │       cardReducer.test.ts
    │   │       categoriesReducer.test.ts
    │   │       productsReducer.test.ts
    │   │       reviewReducer.test.ts
    │   │       usersReducer.test.ts
    │   │
    │   ├───servers
    │   │       categoryServer.ts
    │   │       productServer.ts
    │   │       userServer.ts
    │   │
    │   └───shared
    │           store.ts
    │
    ├───types
    │       Address.ts
    │       Cart.ts
    │       Category.ts
    │       CategoryUpdate.ts
    │       NewProduct.ts
    │       Product.ts
    │       ProductUpdate.ts
    │       Review.ts
    │       User.ts
    │       UserCredential.ts
    │       UserUpdate.ts
    │
    └───utils
            hideEmail.ts
```

<a name="getting-started"></a>

## Getting started

Clone the repository from github:

```
git clone https://github.com/tramnguyenhere/integrify_frontend-project_ecommerce.git
```
