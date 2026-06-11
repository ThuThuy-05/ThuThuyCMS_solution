import React, { useEffect, useState } from "react";
import productService from "../../services/productService";
import ShopSidebar from "./ShopSidebar";
import ShopHeader from "./ShopHeader";
import ProductList from "./ProductList";
import LoadingOrEmpty from "./LoadingOrEmpty";
import { Link } from "react-router-dom";

function Shop() {

    const [products, setProducts] = useState([]);
    const [filteredProducts, setFilteredProducts] = useState([]);
    const [loading, setLoading] = useState(true);

    const [search, setSearch] = useState("");

    useEffect(() => {
        loadProducts();
    }, []);

    const loadProducts = async () => {

        try {

            const data =
                await productService.getAllProducts();

            setProducts(data);
            setFilteredProducts(data);

        }
        catch (error) {
            console.error(error);
        }
        finally {
            setLoading(false);
        }
    };

    const handleSearch = (keyword) => {

        setSearch(keyword);

        const result = products.filter(item =>
            item.name.toLowerCase()
                .includes(keyword.toLowerCase())
        );

        setFilteredProducts(result);
    };

    const handleFilter = ({ minPrice, maxPrice }) => {
        const result = products.filter(item =>
            item.price >= minPrice && item.price <= maxPrice
        );

        setFilteredProducts(result);
    };

    return (

        <div className="container py-5">

           


            <nav className="mb-4">

                <Link
                    to="/"
                    className="text-decoration-none"
                >
                    Trang chủ
                </Link>

                <span className="mx-2">/</span>

                <Link
                    to="/blog"
                    className="text-decoration-none"
                >
                    Cửa hàng
                </Link>

              

            </nav>
            <div className="row">

                <div className="col-lg-3">

                    <ShopSidebar onFilter={handleFilter} />

                </div>

                <div className="col-lg-9">

                    <ShopHeader
                        total={filteredProducts.length}
                        search={search}
                        onSearch={handleSearch}
                    />

                    {loading ? (

                        <LoadingOrEmpty
                            loading={true}
                        />

                    ) : (

                        <ProductList
                            products={filteredProducts}
                        />

                    )}

                </div>

            </div>

        </div>

    );
}

export default Shop;