import React from 'react';
import { Link } from "react-router-dom";
import { Navbar, Nav, NavItem, NavbarBrand, Container } from 'reactstrap';

export const NavMenu = () => {
    return (
        <Navbar color="dark" dark>
            <Container>
                <NavbarBrand >Movies Trailer Finder</NavbarBrand>
                <Nav>
                    <NavItem>
                        <Link className="btn btn-primary" to="/">Home</Link>
                    </NavItem>
                    &ensp;
                    <NavItem>
                        <Link className="btn btn-primary" to="/about">About</Link>
                    </NavItem>
                </Nav>
            </Container>
        </Navbar>
    );
}