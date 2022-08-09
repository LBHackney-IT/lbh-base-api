'use strict';

module.exports = function authorizerPolicy(policy, service) {
    let failed = false;
    const functions = service.compiled['serverless-state.json'].service.functions;

    if (!functions) {
        policy.approve();
        return;
    }

    Object.entries(functions).forEach(([functionName, functionConfig]) => {
        if (!functionConfig.events) return;

        functionConfig.events.forEach((eventConfig) => {
            if (!eventConfig.http) return;
            if (!eventConfig.http.authorizer && eventConfig.http.path!="swagger/{proxy+}") {
                failed = true;
                policy.fail(
                    `Function "${functionName}" does not have an authorizer attached to it. `
                );
            }
        });
    });
    if (!failed) {
        policy.approve();
    }
};
