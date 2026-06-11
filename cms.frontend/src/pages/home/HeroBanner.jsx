import React from "react";
import banner1 from "../../assets/images/banner1.jpeg";
import banner2 from "../../assets/images/banner2.jpeg";
import banner3 from "../../assets/images/banner3.png";

function HeroBanner() {
    return (
        <section className="container my-4">

            <div
                id="heroSlider"
                className="carousel slide"
                data-bs-ride="carousel"
                data-bs-interval="2000"
            >

                {/* Dấu chấm chuyển slide */}
                <div className="carousel-indicators">
                    <button
                        type="button"
                        data-bs-target="#heroSlider"
                        data-bs-slide-to="0"
                        className="active"
                    ></button>

                    <button
                        type="button"
                        data-bs-target="#heroSlider"
                        data-bs-slide-to="1"
                    ></button>

                    <button
                        type="button"
                        data-bs-target="#heroSlider"
                        data-bs-slide-to="2"
                    ></button>
                </div>

                {/* Danh sách ảnh */}
                <div
                    className="carousel-inner rounded-4 shadow"
                    style={{
                        overflow: "hidden"
                    }}
                >

                    <div className="carousel-item active">
                        <img
                            src={banner1}
                            alt="Banner 1"
                            className="d-block w-100"
                            style={{
                                height: "500px",
                                objectFit: "cover"
                            }}
                        />
                    </div>

                    <div className="carousel-item">
                        <img
                            src={banner2}
                            alt="Banner 2"
                            className="d-block w-100"
                            style={{
                                height: "500px",
                                objectFit: "cover"
                            }}
                        />
                    </div>

                    <div className="carousel-item">
                        <img
                            src={banner3}
                            alt="Banner 3"
                            className="d-block w-100"
                            style={{
                                height: "500px",
                                objectFit: "cover"
                            }}
                        />
                    </div>

                </div>

                {/* Nút trái */}
                <button
                    className="carousel-control-prev"
                    type="button"
                    data-bs-target="#heroSlider"
                    data-bs-slide="prev"
                >
                    <span className="carousel-control-prev-icon"></span>
                </button>

                {/* Nút phải */}
                <button
                    className="carousel-control-next"
                    type="button"
                    data-bs-target="#heroSlider"
                    data-bs-slide="next"
                >
                    <span className="carousel-control-next-icon"></span>
                </button>

            </div>

        </section>
    );
}

export default HeroBanner;