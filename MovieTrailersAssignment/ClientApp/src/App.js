import React from 'react';
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import { Home } from './components/Home';
import { About } from './components/About';
import { NavMenu } from './components/NavMenu';
import './custom.css'

function App() {
    return (
        <Router>
            <NavMenu />
            <Switch>
                <Route exact path="/" component={Home} />
                <Route path="/about" component={About} />
            </Switch>
        </Router>
    );
}
export default App;
